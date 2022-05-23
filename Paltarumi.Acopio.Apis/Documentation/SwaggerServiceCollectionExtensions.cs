using Microsoft.OpenApi.Models;
using Paltarumi.Acopio.Apis.Base;

namespace Paltarumi.Acopio.Apis.Documentation
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection UseSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("ApiOptions").Get<ApiOptions>();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    string.Format(SwaggerDefaults.DocInfoVersion, options.Version),
                    new OpenApiInfo
                    {
                        Title = string.Format(SwaggerDefaults.DocInfoTitle, options.Name, options.Version, options.Environment),
                        Version = string.Format(SwaggerDefaults.DocInfoVersion, options.Version),
                        Contact = new OpenApiContact()
                        {
                            Name = options.ContactName,
                            Url = !string.IsNullOrEmpty(options.ContactUrl) ? new Uri(options.ContactUrl) : null
                        }
                    }
                );
            });

            return services;
        }
    }
}
