using System.Threading.Tasks;
using System.Collections.Generic;
using FlightService.Domain.Entities;

namespace FlightService.Application.Contracts.Persistence
{
    public interface IFlightDapperRepository : IAsyncDapperRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetUnscheduledFlights();
    }
}