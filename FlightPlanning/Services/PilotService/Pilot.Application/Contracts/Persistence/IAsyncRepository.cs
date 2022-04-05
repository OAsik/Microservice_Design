using Pilot.Domain.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetPilots();

        Task<T> GetSinglePilot(string employeeNumber);

        Task<bool> InsertPilot(PilotEntity pilot);

        Task<bool> UpdatePilot(PilotEntity pilot);

        Task<bool> DeletePilot(T entity);
    }
}