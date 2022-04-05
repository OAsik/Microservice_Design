using System.Threading.Tasks;
using FlightService.Domain.Common;
using FlightService.Domain.Entities;

namespace FlightService.Application.Contracts.Persistence
{
    public interface IAsyncEFRepository<T> where T : EntityBase
    {
        Task<T> InsertFlight(Flight flight);

        Task UpdateFlight(Flight flight);

        Task DeleteFlight(T entity);
    }
}