using EfCore.Core.DbContexts;
using EfCore.Core.ManagingSchemas.EnsureCreated;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfCore.Core.EnsureCreateds.TwoContextsEnsurance
{
    public class EnsureCreationSameDatabase
    {
        public static void EnsuranceCreationForBothContextInSameDatabase()
        {
            var sampleContextA = new ContextSampleA();
            var sampleContextB = new ContextSampleB();

            new Ensurance(sampleContextA).EnsureCreated();
            new Ensurance(sampleContextB).EnsureCreated();
        }

        public static void ForceEnsuranceCreationForBothContextInSameDatabase()
        {
            var sampleContextA = new ContextSampleA();
            var sampleContextB = new ContextSampleB();

            new Ensurance(sampleContextA).EnsureCreated();
            new Ensurance(sampleContextB).EnsureCreated();

            var databaseForceCreation = sampleContextB.GetService<IRelationalDatabaseCreator>();
            databaseForceCreation.CreateTables();
        }
    }
}
