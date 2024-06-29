using EfCore.Core.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.EntitiesTypeConfiguration
{
    /// <summary>
    /// GroupingConfiguration:
    /// Para reduzir o tamanho do método OnModelCreating, toda configuração de um tipo de entidade
    /// pode ser extraída para uma classe separada implementando <see cref="IEntityTypeConfiguration"/>
    /// </summary>
    public class DreamConfiguration : IEntityTypeConfiguration<Dream>
    {
        public void Configure(EntityTypeBuilder<Dream> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Peoples)
                    .WithOne(x => x.Dream)
                    .HasForeignKey(x => x.DreamId);
        }
    }
}
