using Paltarumi.Acopio.Apis.Base;

namespace Paltarumi.Acopio.Apis.Endpoints
{
    public static class RootApiEndpointApplicationBuilderExtensions
    {
        public static void UseRootApiEndpoint(this IApplicationBuilder app, IConfiguration configuration)
        {
            var options = configuration.GetSection("ApiOptions").Get<ApiOptions>();

            app.UseEndpoints(configure =>
            {
                configure.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"{options.Name} Api - v{options.Version} ({options.Environment})");
                });
            });
        }
    }
}
