using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfCore.Core.EntitiesTypeConfiguration
{
    /// <summary>
    /// Aplicar todas as configurações em um assembly:
    /// É possível aplicar todas as configurações especificadas em tipos que implementam <see cref="IEntityTypeConfiguration"/>
    /// em um determinado assembly.
    /// </summary>
    public static class ApplicationGroupingConfiguration
    {
        public static void ApplyAllConfigurations(ModelBuilder modelBuilder)
        {
            var currentAssembly = Assembly.GetEntryAssembly() ?? throw new Exception($"invalid assembly on {nameof(ApplicationGroupingConfiguration)}");

            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
        }
    }
}
