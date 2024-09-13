namespace BookingSystem.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        // Use IApplicationBuilder to add middleware.
        // IApplicationBuilder is used to build the request pipeline.
        // UseMiddleware<T> method is used to add middleware to the request pipeline.
        // UseCustomExceptionHandler method is used to add CustomExceptionHandlerMiddleware to the request pipeline.
        // The instance of IApplicationBuilder is the one initialized in the Program.cs file.

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
