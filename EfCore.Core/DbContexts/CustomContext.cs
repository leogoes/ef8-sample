using EfCore.Core.Entities;
using EfCore.Core.EntitiesTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using EfCore.Infrastructure.Loggings;

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

    public class ContextSampleA() : DbContext
    {
        private readonly StreamWriter writer = new("local_file_ef_log.txt", append: true);
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Person> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONTEXT_A") ?? throw new MissingFieldException("Missing Environment: DB_PRIMARY_HOST");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

            optionsBuilder.UseMySql(connectionString, serverVersion, options =>
            {
                options.EnableRetryOnFailure();
            })
            .WriteLogToFile(writer);
        }

        public override void Dispose()
        {
            base.Dispose();
            writer.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplicationGroupingConfiguration.ApplyAllConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ContextSampleB : DbContext
    {
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Person> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONTEXT_B") ?? throw new MissingFieldException("Missing Environment: DB_PRIMARY_HOST");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

            optionsBuilder.UseMySql(connectionString, serverVersion, options =>
            {
                options.EnableRetryOnFailure();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplicationGroupingConfiguration.ApplyAllConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
