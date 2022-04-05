using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightService.Domain.Entities;

namespace FlightService.Infrastructure.Persistence
{
    public class FlightContextSeed
    {
        public static async Task SeedAsync(FlightContext flightContext)
        {
            if (!flightContext.Flight.Any())
            {
                flightContext.Flight.AddRange(GetPregeneratedFlights());

                await flightContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Flight> GetPregeneratedFlights()
        {
            return new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "TK1027",
                    Origin = "IST",
                    Destination = "SOF",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1021",
                    Origin = "IST",
                    Destination = "SJJ",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1035",
                    Origin = "IST",
                    Destination = "BUD",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1869",
                    Origin = "IST",
                    Destination = "VCE",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1883",
                    Origin = "IST",
                    Destination = "VIE",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK8160",
                    Origin = "IST",
                    Destination = "KRK",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1937",
                    Origin = "IST",
                    Destination = "BRU",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1553",
                    Origin = "IST",
                    Destination = "HAJ",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1951",
                    Origin = "IST",
                    Destination = "AMS",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1389",
                    Origin = "IST",
                    Destination = "BOD",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1925",
                    Origin = "IST",
                    Destination = "BSL",
                    HasScheduled = false,
                    IsActive = true
                },
                new Flight()
                {
                    FlightNumber = "TK1795",
                    Origin = "IST",
                    Destination = "EDI",
                    HasScheduled = false,
                    IsActive = true
                },
            };
        }
    }
}