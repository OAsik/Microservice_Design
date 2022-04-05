using System.Threading.Tasks;
using FlightService.Domain.Entities;

namespace FlightService.Application.Contracts.Persistence
{
    public interface IFlightEFRepository : IAsyncEFRepository<Flight>
    {
        Task ScheduleFlight(Flight flight);
    }
}