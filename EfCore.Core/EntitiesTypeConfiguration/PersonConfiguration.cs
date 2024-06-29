using EfCore.Core.Enities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.EntitiesTypeConfiguration
{
    /// <summary>
    /// GroupingConfiguration:
    /// Para reduzir o tamanho do método OnModelCreating, toda configuração de um tipo de entidade
    /// pode ser extraída para uma classe separada implementando <see cref="IEntityTypeConfiguration"/>
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Sleeps)
                    .WithOne(x => x.Person)
                    .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.Dream)
                   .WithMany(x => x.Peoples)
                    .HasForeignKey(x => x.DreamId);
        }
    }
}
