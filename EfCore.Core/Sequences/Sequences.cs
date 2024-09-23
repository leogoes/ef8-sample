using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.Sequences
{
    public class Sequences
    {
        public static void CustomSequence(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("CUSTOM_SEQUENCE", "SEQUENCE")
                        .StartsAt(1)
                        .IncrementsBy(2)
                        .HasMax(10)
                        .HasMin(1)
                        .IsCyclic();

            modelBuilder.Entity<Person>().Property(x => x.Id).HasDefaultValueSql("NEXT VALUE FOR SEQUENCE.CUSTOM_SEQUENCE");
        }
    }
}
