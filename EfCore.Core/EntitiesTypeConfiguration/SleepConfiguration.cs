using EfCore.Core.Enities;
using EfCore.Core.OwnsEntityTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Core.EntitiesTypeConfiguration
{
    /// <summary>
    /// GroupingConfiguration:
    /// Para reduzir o tamanho do método OnModelCreating, toda configuração de um tipo de entidade ]
    /// pode ser extraída para uma classe separada implementando <see cref="IEntityTypeConfiguration"/>
    /// </summary>
    public class SleepConfiguration : IEntityTypeConfiguration<Sleep>
    {
        public void Configure(EntityTypeBuilder<Sleep> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
                   .WithMany(x => x.Sleeps)
                   .HasForeignKey(x => x.PersonId);

            builder.OwnsOne(x => x.Noise);

            builder.OwnsMany(x => x.CountOfSheeps, sheep =>
            {
                sheep.WithOwner().HasForeignKey(x => x.SleepId);

                sheep.Property(x => x.Id);
                sheep.Property(x => x.Number).HasColumnName("SheepNumber");
                sheep.Property(x => x.Name).HasColumnName("SheepName");

                sheep.HasKey(x => x.Id);
            });

            //SleepOwnedTypes.OwnsOneNoise(builder);
            //SleepOwnedTypes.OwnsManyCountOfSheeps(builder);
        }
    }
}
