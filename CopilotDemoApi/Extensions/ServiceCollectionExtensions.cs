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
            services
                .AddScoped<IRealPropertyService, RealPropertyService>()
                .AddScoped<ILiteDbService, LiteDbService>()
                .AddScoped<IAdvertisementGenerationService, AdvertisementGenerationService>()
                .AddScoped<IActivityLogService, ActivityLogService>();

            return services;
        }
    }
}
