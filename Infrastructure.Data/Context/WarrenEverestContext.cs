using DomainModels.Models;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class WarrenEverestContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
        }

        public WarrenEverestContext(DbContextOptions<WarrenEverestContext> options) :base(options)
        {
        }

    }
}
