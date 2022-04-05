using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FlightService.Infrastructure.Extensions;
using FlightService.Infrastructure.Persistence;

namespace Flight.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.MigrateDatabase<FlightContext>((context, services) => {
                FlightContextSeed.SeedAsync(context).Wait();
            });

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}