using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.ManagingSchemas.MIgrations
{
    public class ManagingMigrations
    {
        public static void GenerateDatabaseScript(CustomContext context)
        {
            var script = context.Database.GenerateCreateScript();

            Console.WriteLine(script);
        }

        public static void GetAppliedMigrations(CustomContext context)
        {
            var listOfAppliedMigrations = context.Database.GetAppliedMigrations();

            Console.WriteLine($"List de migrações aplicadas: {listOfAppliedMigrations.Count()}");

            foreach (var appliedMigration in listOfAppliedMigrations)
            {

                Console.WriteLine($"Migração aplicada: {appliedMigration}");
            }
        }

        public static void GetMigrations(CustomContext context)
        {
            var listOfMigrations = context.Database.GetMigrations();

            Console.WriteLine($"List de migrações: {listOfMigrations.Count()}");

            foreach (var migration in listOfMigrations)
            {

                Console.WriteLine($"Migração: {migration}");
            }
        }

        public static void GetPendingMigrations(CustomContext context)
        {
            var listOfPendingMigrations = context.Database.GetPendingMigrations();

            Console.WriteLine($"List de migrações pendentes: {listOfPendingMigrations.Count()}");

            foreach (var pendingMigration in listOfPendingMigrations)
            {

                Console.WriteLine($"Migração pendente: {pendingMigration}");
            }
        }

        public static void ApplyMigrationInExecutionTime(CustomContext context)
        {
            context.Database.Migrate();
        }
    }
}
