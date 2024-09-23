using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.Indexes
{
    public class Indexes
    {
        public static void CreateIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        //.HasIndex(p => p.Name)
                        .HasIndex(p => new { p.Name, p.DreamId })
                        .HasDatabaseName("idx_my_custom_index")
                        .HasFilter("Name IS NOT NULL")
                        .IsUnique();
        }
    }
}
