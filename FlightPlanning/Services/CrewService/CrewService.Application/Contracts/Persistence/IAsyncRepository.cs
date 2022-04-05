using System.Threading.Tasks;
using CrewService.Domain.Common;
using System.Collections.Generic;
using CrewService.Domain.Entities;

namespace CrewService.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetCrews();

        Task<T> GetSingleCrew(string id);

        Task<string> InsertCrew(Crew crew);

        Task<bool> UpdateCrew(Crew crew);

        Task<bool> DeleteCrew(string id);
    }
}