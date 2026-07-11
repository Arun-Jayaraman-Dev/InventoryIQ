using InventoryIQ.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace InventoryIQ.Infrastructure.Persistence
{
    public sealed class InventoryIQDbContext : DbContext
    {
        public InventoryIQDbContext(DbContextOptions<InventoryIQDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryIQDbContext).Assembly);
        }
    }
}