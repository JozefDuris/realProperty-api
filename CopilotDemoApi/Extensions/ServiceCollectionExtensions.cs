using CopilotDemoApi.Services;

namespace CopilotDemoApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAllTypes(this IServiceCollection services)
        {
            services.AddTransient<IRealPropertyService, RealPropertyService>();
            services.AddTransient<ILiteDbService, LiteDbService>();
            services.AddTransient<IAdvertisementGenerationService, AdvertisementGenerationService>(); 

            return services;
        }
    }
}
