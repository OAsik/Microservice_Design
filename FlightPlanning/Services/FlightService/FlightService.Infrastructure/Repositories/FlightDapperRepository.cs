using Dapper;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using FlightService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using FlightService.Application.Contracts.Persistence;

namespace FlightService.Infrastructure.Repositories
{
    public class FlightDapperRepository : IFlightDapperRepository
    {
        private readonly IConfiguration _configuration;

        public FlightDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:FlightConnectionString"));

            var flights = await connection.QueryAsync<Flight>("select * from Flight");

            return flights;
        }

        public async Task<Flight> GetSingleFlight(string flightNumber)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:FlightConnectionString"));

            var flight = await connection.QueryFirstOrDefaultAsync<Flight>("select * from Flight where FlightNumber = @FlightNumber", new { FlightNumber = flightNumber });

            return flight;
        }

        public async Task<IEnumerable<Flight>> GetUnscheduledFlights()
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:FlightConnectionString"));

            var unscheduledFlights = await connection.QueryAsync<Flight>("select * from Flight where HasScheduled = false");

            return unscheduledFlights;
        }
    }
}