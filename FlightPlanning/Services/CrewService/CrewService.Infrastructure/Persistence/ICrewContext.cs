using MongoDB.Driver;
using CrewService.Domain.Entities;

namespace CrewService.Infrastructure.Persistence
{
    public interface ICrewContext
    {
        IMongoCollection<Crew> Crew { get; }
    }
}