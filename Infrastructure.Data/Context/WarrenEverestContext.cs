using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.Context
{
    public class WarrenEverestContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
            modelBuilder.Entity<Portfolio>()
                .HasMany(portfolio => portfolio.Products)
                .WithMany(product => product.Porfolios)
                .UsingEntity<PortfolioProduct>(entity => entity.ToTable("PortfolioProducts"));
        }

        public WarrenEverestContext(DbContextOptions<WarrenEverestContext> options) :base(options)
        {
        }
    }
}
