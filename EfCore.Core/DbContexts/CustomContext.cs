using EfCore.Core.Enities;
using EfCore.Core.EntitiesTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.DbContexts
{
    public class CustomContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Person> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplicationGroupingConfiguration.ApplyAllConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
