using BookingSystem.Api.Middleware;
using BookingSystem.Api.Services;
using BookingSystem.Application;
using BookingSystem.Application.Contracts.Services;
using BookingSystem.Persistence;

namespace BookingSystem.Api
{
    // use web application builder to add services
    //use web application to configure pipeline
    public static class Startup
    {
        
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersitenceServices(builder.Configuration);
            builder.Services.AddControllers();

            builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserDataService>();

            // The front-end application will be hosted on a different domain, so we need to enable CORS
            // This allows the front-end application to make requests to the API for resources such as Images, Icons, etc.
            // In this case, we are allowing all methods, headers, and origins
            // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0

            builder.Services.AddCors(options =>
            {
                // the open policy should apply only to the Api domain and the front-end application domain.
                options.AddPolicy("open", policyBuilder =>
                {
                    //allow requests from the front-end application and the current domain
                    //register the front-end application url in the appsettings.json file
                    //requests from the domain of the front-end application will be allowed

                    policyBuilder
                        .WithOrigins(
                        builder.Configuration["ApiUrl"] ?? "https://localhost:7171",
                        builder.Configuration["WebAppUrl"] ?? "https://localhost:7173/",
                        builder.Configuration["MobileAppUrl"] ?? "https://10.0.2.2/")
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(pol => true)
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });


            builder.Services.AddHttpContextAccessor();
            //add swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //add cors later

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            // browser security prevents a web page from making requests to a different domain
            // than the one that served the web page
            //use cors to allow requests from the front-end application
            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // use custom exception handler to handle exceptions
            // when exceptions are thrown in the application they bubble up to the middleware
            // the middleware catches the exception and returns a response to the client
            // the response is a json object with the exception message
            // the error message is in the response body
            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

    }
}
