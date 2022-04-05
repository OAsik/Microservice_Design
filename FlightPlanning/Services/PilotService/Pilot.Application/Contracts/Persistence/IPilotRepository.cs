using System.Threading.Tasks;
using System.Collections.Generic;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Application.Contracts.Persistence
{
    public interface IPilotRepository : IAsyncRepository<PilotEntity>
    {
        Task<IEnumerable<PilotEntity>> FindUnscheduledPilots();
    }
}
