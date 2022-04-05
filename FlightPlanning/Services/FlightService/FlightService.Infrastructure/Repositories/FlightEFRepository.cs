using System.Threading.Tasks;
using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FlightService.Infrastructure.Persistence;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Infrastructure.Repositories
{
    public class FlightEFRepository : IFlightEFRepository
    {
        private readonly FlightContext _context;

        public FlightEFRepository(FlightContext context)
        {
            _context = context;
        }

        public async Task<Flight> InsertFlight(Flight flight)
        {
            _context.Set<Flight>().Add(flight);

            await _context.SaveChangesAsync();

            return flight;
        }

        public async Task UpdateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlight(Flight flight)
        {
            flight.IsActive = false;

            _context.Entry(flight).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        

        public async Task ScheduleFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}