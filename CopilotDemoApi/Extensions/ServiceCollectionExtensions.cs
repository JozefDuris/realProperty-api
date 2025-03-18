using CopilotDemoApi.InfrastructureAdapters;
using CopilotDemoApi.InfrastructureAdapters.Interfaces;
using CopilotDemoApi.Services;
using CopilotDemoApi.Services.Interfaces;

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
