using DomainModels.Models;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public class WarrenEverestContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
        }

        public WarrenEverestContext(DbContextOptions<WarrenEverestContext> options) :base(options)
        {
        }
    }
}
