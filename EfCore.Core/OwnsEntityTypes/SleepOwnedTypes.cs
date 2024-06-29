using EfCore.Core.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Core.OwnsEntityTypes
{
    public class SleepOwnedTypes
    {
        /// <summary>
        /// OwnsMany: <see href="https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities#collections-of-owned-types"/>
        /// </summary>
        /// <param name="builder"></param>
        public static void OwnsManyCountOfSheeps(EntityTypeBuilder<Sleep> builder) 
            => builder.OwnsMany(x => x.CountOfSheeps, sheep =>
            {
                sheep.WithOwner().HasForeignKey(x => x.SleepId);
                
                sheep.Property(x => x.Id);
                sheep.Property(x => x.Number).HasColumnName("SheepNumber");
                sheep.Property(x => x.Name).HasColumnName("SheepName");

                sheep.HasKey(x => x.Id);
            });


        /// <summary>
        /// OwnsOne: <see href="https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities#configuring-types-as-owned"/> 
        /// </summary>
        /// <param name="builder"></param>
        public static void OwnsOneNoise(EntityTypeBuilder<Sleep> builder) 
            => builder.OwnsOne(x => x.Noise);
    }
}
