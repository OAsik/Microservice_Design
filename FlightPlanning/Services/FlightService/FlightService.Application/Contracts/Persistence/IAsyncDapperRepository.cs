using System.Threading.Tasks;
using System.Collections.Generic;
using FlightService.Domain.Common;

namespace FlightService.Application.Contracts.Persistence
{
    public interface IAsyncDapperRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetFlights();

        Task<T> GetSingleFlight(string flightNumber);
    }
}