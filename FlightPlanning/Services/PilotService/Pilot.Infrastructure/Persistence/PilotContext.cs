using Npgsql;

namespace Pilot.Infrastructure.Persistence
{
    public class PilotContext : IPilotContext
    {
        public PilotContext(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);

            connection.Open();
        }

        public NpgsqlConnection connection { get; }
    }
}