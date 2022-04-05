using Npgsql;
using System;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pilot.Infrastructure.Persistence;
using Pilot.Application.Contracts.Persistence;
using PilotEntity = Pilot.Domain.Entities.Pilot;

namespace Pilot.Infrastructure.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly IPilotContext _context;

        public PilotRepository(IPilotContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PilotEntity>> GetPilots()
        {
            var pilots = await _context.connection.QueryAsync<PilotEntity>("select * from Pilot");

            CloseConnection(_context.connection);

            return pilots;
        }

        public async Task<PilotEntity> GetSinglePilot(string employeeNumber)
        {
            var pilot = await _context.connection.QueryFirstOrDefaultAsync<PilotEntity>("select * from Pilot where EmployeeNumber = @EmployeeNumber", new { EmployeeNumber = employeeNumber });

            CloseConnection(_context.connection);

            return pilot;
        }

        public async Task<IEnumerable<PilotEntity>> FindUnscheduledPilots()
        {
            var freePilots = await _context.connection.QueryAsync<PilotEntity>("select * from Pilot where HasSchedule = false");

            CloseConnection(_context.connection);

            return freePilots;
        }

        public async Task<bool> InsertPilot(PilotEntity pilot)
        {
            pilot.IsActive = true;
            pilot.CreateTime = DateTime.Now;

            var affectedRow = await _context.connection.ExecuteAsync("insert into Pilot (EmployeeNumber, FirstName, LastName, IsCaptain, HasSchedule, CreateTime, IsActive) values (@EmployeeNumber, @FirstName, @LastName, @IsCaptain, @HasSchedule, @CreateTime, @IsActive)", new { EmployeeNumber = pilot.EmployeeNumber, FirstName = pilot.FirstName, LastName = pilot.LastName, IsCaptain = pilot.IsCaptain, HasSchedule = pilot.HasSchedule, CreateTime = pilot.CreateTime, IsActive = pilot.IsActive });

            CloseConnection(_context.connection);

            return !(affectedRow == 0);
        }

        public async Task<bool> UpdatePilot(PilotEntity pilot)
        {
            pilot.UpdateTime = DateTime.Now;

            var affectedRow = await _context.connection.ExecuteAsync("update Pilot set EmployeeNumber = @EmployeeNumber, FirstName = @FirstName, LastName = @LastName, IsCaptain = @IsCaptain, HasSchedule = @HasSchedule, UpdateTime = @UpdateTime where Id = @Id", new { EmployeeNumber = pilot.EmployeeNumber, FirstName = pilot.FirstName, LastName = pilot.LastName, IsCaptain = pilot.IsCaptain, HasSchedule = pilot.HasSchedule, Id = pilot.Id, UpdateTime = pilot.UpdateTime });

            CloseConnection(_context.connection);

            return !(affectedRow == 0);
        }

        public async Task<bool> DeletePilot(PilotEntity pilot)
        {
            pilot.UpdateTime = DateTime.Now;
            pilot.IsActive = false;

            var affectedRow = await _context.connection.ExecuteAsync("update Pilot set UpdateTime = @UpdateTime, IsActive = @IsActive where Id = @Id", new { Id = pilot.Id, UpdateTime = pilot.UpdateTime, IsActive = pilot.IsActive });

            CloseConnection(_context.connection);

            return !(affectedRow == 0);
        }

        private void CloseConnection(NpgsqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}