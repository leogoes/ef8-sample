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
                   .HasForeignKey(x => x.Id);

            SleepOwnedTypes.OwnsOneNoise(builder);
            SleepOwnedTypes.OwnsManyCountOfSheeps(builder);
        }
    }
}
