using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options): base(options)
        {
                
        }

        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderLineModel> OrderLine { get; set; }
        public DbSet<LookupModel> Lookup { get; set; }
        public DbSet<LookupTypeModel> LookupType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
