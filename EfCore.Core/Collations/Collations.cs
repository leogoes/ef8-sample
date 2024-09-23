using EfCore.Core.DbContexts;
using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.Collations
{
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/ef/core/miscellaneous/collations-and-case-sensitivity"/>
    /// </summary>
    public class Collations
    {
        public static void ChangeDefaultDatabaseCollation(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
        }

        public static void ChangeDefaultPropertyCollation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(c => c.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        }

        /// <summary>
        /// SELECT [c].[Id], [c].[Name]
        /// FROM[Customers] AS[c]
        /// WHERE[c].[Name]
        /// COLLATE SQL_Latin1_General_CP1_CS_AS = N'John'
        /// </summary>
        /// <param name="context"></param>
        public static void ChangeDefaultQueryCollation(CustomContext context)
        {
            var customers = context.Peoples
                .Where(c => EF.Functions.Collate(c.Name, "SQL_Latin1_General_CP1_CS_AS") == "John")
                .ToList();
        }
    }
}
