using CopilotDemo.Application.Interfaces;
using CopilotDemo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CopilotDemo.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddScoped<IRealPropertyService, RealPropertyService>()
                .AddScoped<IAdvertisementGenerationService, AdvertisementGenerationService>()
                .AddScoped<IActivityLogService, ActivityLogService>();

            return services;
        }
    }
}
