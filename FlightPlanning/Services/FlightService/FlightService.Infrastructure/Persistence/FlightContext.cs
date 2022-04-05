using System;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Domain.Common;
using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Persistence
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        public DbSet<Flight> Flight { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdateTime = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateTime = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}