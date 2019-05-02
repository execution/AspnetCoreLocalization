using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Linq;


namespace AspnetCoreLocalization.Utilities
{
    public static class LocalizationExtension
    {
        /// <summary>
        /// localize request according to {culture} route value.
        /// define supported cultures list, 
        /// define default culture for fallback,
        /// customize culture info e.g.: dat time format, digit shape,...
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRequestLocalization(this IServiceCollection services)
        {
            var cultures = new CultureInfo[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("th-TH"),
         
               
            };

            services.Configure<RequestLocalizationOptions>(ops =>
            {
                ops.DefaultRequestCulture = new RequestCulture("en-US");
                ops.SupportedCultures = cultures.OrderBy(x => x.EnglishName).ToList();
                ops.SupportedUICultures = cultures.OrderBy(x => x.EnglishName).ToList();

                // add RouteValueRequestCultureProvider to the beginning of the providers list. 
                ops.RequestCultureProviders.Insert(0,
                    new RouteValueRequestCultureProvider(cultures));
            });
        }
    }
}
