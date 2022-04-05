using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using CrewService.Domain.Entities;
using CrewService.Infrastructure.Persistence;
using CrewService.Application.Contracts.Persistence;

namespace CrewService.Infrastructure.Repositories
{
    public class CrewRepository : ICrewRepository
    {
        private readonly ICrewContext _context;

        public CrewRepository(ICrewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Crew>> GetCrews()
        {
            //return await _context.Crew.Find(x => true).ToListAsync();

            return await _context.Crew.Find(x => x.IsActive).ToListAsync();
        }

        public async Task<Crew> GetSingleCrew(string id)
        {
            FilterDefinition<Crew> filter = Builders<Crew>.Filter.Eq(x => x.EmployeeNumber, id);

            return await _context.Crew.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Crew>> FindSeniorStaff()
        {
            return await _context.Crew.Find(x => x.IsSenior).ToListAsync();
        }

        public async Task<string> InsertCrew(Crew crew)
        {
            crew.IsActive = true;
            crew.CreateTime = DateTime.Now;
            crew.HasSchedule = false;

            await _context.Crew.InsertOneAsync(crew);

            return crew.Id;
        }

        public async Task<bool> UpdateCrew(Crew crew)
        {
            crew.UpdateTime = DateTime.Now;

            var updateResult = await _context.Crew.ReplaceOneAsync(filter: x => x.Id == crew.Id, replacement: crew);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteCrew(string id)
        {
            FilterDefinition<Crew> filter = Builders<Crew>.Filter.Eq(x => x.Id, id);

            var userToDelete = await _context.Crew.Find(filter).FirstOrDefaultAsync();

            userToDelete.IsActive = false;
            userToDelete.UpdateTime = DateTime.Now;

            var deleteResult = await _context.Crew.ReplaceOneAsync(filter: x => x.Id == id, replacement: userToDelete);

            return deleteResult.IsAcknowledged && deleteResult.ModifiedCount > 0;
        }        
    }
}