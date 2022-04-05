using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FlightService.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using FlightService.Infrastructure.Repositories;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlightContext>(options => options.UseSqlServer(configuration.GetConnectionString("FlightConnectionString")));
            services.AddScoped<IFlightDapperRepository, FlightDapperRepository>();
            services.AddScoped<IFlightEFRepository, FlightEFRepository>();

            return services;
        }
    }
}