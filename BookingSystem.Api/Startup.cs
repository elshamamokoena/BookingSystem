using BookingSystem.Api.Middleware;
using BookingSystem.Api.Services;
using BookingSystem.Application;
using BookingSystem.Application.Contracts.Services;
using BookingSystem.AuthorizationPolicies;
using BookingSystem.Identity;
using BookingSystem.Persistence;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using static System.Net.WebRequestMethods;

namespace BookingSystem.Api
{
    // use web application builder to add services
    //use web application to configure pipeline
    public static class Startup
    {
        
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
    //        AddSwagger(builder.Services);
            builder.Services.AddApplicationServices();
            builder.Services.AddPersitenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserDataService>();

            // The front-end application will be hosted on a different domain, so we need to enable CORS
            // This allows the front-end application to make requests to the API for resources such as Images, Icons, etc.
            // In this case, we are allowing all methods, headers, and origins
            // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0

            builder.Services.AddCors(options =>
            {
                    //  the open policy should apply only to the Api domain and the front-end application domain.
                    options.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                    //  allow requests from the front-end application and the current domain
                    //  register the front-end application url in the appsettings.json file
                    //  requests from the domain of the front-end application will be allowed
            });


            //add swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = builder.Configuration["Authority"];
            //        options.Audience = builder.Configuration["Audience"];
            //        options.MapInboundClaims = false;
            //        options.TokenValidationParameters= new TokenValidationParameters
            //        {
            //            NameClaimType = JwtRegisteredClaimNames.Name,
            //            RoleClaimType = "roles",
            //            ValidIssuer = "https://sts.windows.net/d8bf7c18-5725-4b9e-b118-13388f52e44e/",
            //        };
            //    });

 

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseCustomExceptionHandler();
            app.UseCors("open");
            app.UseAuthorization();

            // use custom exception handler to handle exceptions
            // when exceptions are thrown in the application they bubble up to the middleware
            // the middleware catches the exception and returns a response to the client
            // the response is a json object with the exception message
            // the error message is in the response body
            app.MapControllers();

            return app;
        }
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookingSystem.Api",

                });
            });
        }
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<BookingSystemDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // log the error
            }
        }

    }
}
