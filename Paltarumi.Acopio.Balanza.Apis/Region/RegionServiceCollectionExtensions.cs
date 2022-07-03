using Microsoft.AspNetCore.Localization;
using Paltarumi.Acopio.Balanza.Apis.Base;
using System.Globalization;

namespace Paltarumi.Acopio.Balanza.Apis.Region
{
    //TODO: UTC
    public static class RegionServiceCollectionExtensions
    {
        public static IServiceCollection UseRegion(this IServiceCollection services, IConfiguration configuration)
        {
            var apiOntion = configuration.GetSection("ApiOptions").Get<ApiOptions>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(apiOntion.Region!)
                };

                options.DefaultRequestCulture = new RequestCulture(culture: apiOntion.Region!, uiCulture: apiOntion.Region!);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

            });

            return services;
        }
    }
}
