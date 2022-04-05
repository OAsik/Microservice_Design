using System.Threading.Tasks;
using System.Collections.Generic;
using CrewService.Domain.Entities;

namespace CrewService.Application.Contracts.Persistence
{
    public interface ICrewRepository : IAsyncRepository<Crew>
    {
        Task<IEnumerable<Crew>> FindSeniorStaff();
    }
}