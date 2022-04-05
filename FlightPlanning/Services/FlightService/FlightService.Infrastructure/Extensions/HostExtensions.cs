using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlightService.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder, int? retry = 0) where TContext : DbContext
        {
            int retryAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetService<TContext>();

                try
                {
                    InvokeSeeder(seeder, context, services);
                }
                catch (SqlException)
                {
                    if (retryAvailability < 50)
                    {
                        retryAvailability++;

                        System.Threading.Thread.Sleep(2000);

                        MigrateDatabase<TContext>(host, seeder, retryAvailability);
                    }
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();

            seeder(context, services);
        }
    }
}