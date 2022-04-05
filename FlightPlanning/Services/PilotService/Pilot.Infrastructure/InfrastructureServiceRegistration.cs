using Pilot.Infrastructure.Persistence;
using Pilot.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Pilot.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Pilot.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPilotRepository, PilotRepository>();
            services.AddTransient<IPilotContext>(serviceProvider => new PilotContext(configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

            return services;
        }
    }
}