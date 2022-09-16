using DomainModels.Models;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class WarrenEverestContext : DbContext
    {
        #region Props
        public DbSet<Customer> Customer { get; set; }
        #endregion

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
        }
        #endregion

        public WarrenEverestContext(DbContextOptions<WarrenEverestContext> options) :base(options)
        {
        }

    }
}
