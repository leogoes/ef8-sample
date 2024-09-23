using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Infrastructure.Collations
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
    }
}
