using Microsoft.Extensions.Configuration;
using CrewService.Infrastructure.Persistence;
using CrewService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CrewService.Application.Contracts.Persistence;

namespace CrewService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddTransient<ICrewContext>(serviceProvider => new CrewContext(configuration.GetValue<string>("DatabaseSettings:ConnectionString"), configuration.GetValue<string>("DatabaseSettings:DatabaseName"), configuration.GetValue<string>("DatabaseSettings:CollectionName")));

            return services;
        }
    }
}