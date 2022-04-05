using Npgsql;

namespace Pilot.Infrastructure.Persistence
{
    public interface IPilotContext
    {
        NpgsqlConnection connection { get;  }
    }
}