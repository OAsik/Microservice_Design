using MongoDB.Driver;
using CrewService.Domain.Entities;

namespace CrewService.Infrastructure.Persistence
{
    public class CrewContext : ICrewContext
    {
        public CrewContext(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(databaseName);

            Crew = database.GetCollection<Crew>(collectionName);

            CrewContextSeed.SeedData(Crew);
        }

        public IMongoCollection<Crew> Crew { get; }
    }
}