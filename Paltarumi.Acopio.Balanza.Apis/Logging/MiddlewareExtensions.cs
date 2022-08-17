namespace Paltarumi.Acopio.Balanza.Apis.Logging
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection UseRequestLogger(this IServiceCollection services)
            => services.AddSingleton<RequestLoggerMiddleware>();

        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
            => builder.UseMiddleware<RequestLoggerMiddleware>();
    }
}
