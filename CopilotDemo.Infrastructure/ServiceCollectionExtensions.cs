using CopilotDemo.Infrastructure.Interfaces;
using CopilotDemo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CopilotDemo.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services
                .AddScoped<ILiteDbService, LiteDbService>();

            return services;
        }
    }
}
