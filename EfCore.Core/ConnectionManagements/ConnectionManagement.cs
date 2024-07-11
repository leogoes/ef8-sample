using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EfCore.Core.ConnectionManagements
{
    public class ConnectionManagement
    {

        public static int _count;
        public static void WarmUp(CustomContext context) => context.Peoples.AsNoTracking().Any();

        public static void ManageConnection(CustomContext context)
        {
            var time = Stopwatch.StartNew();

            for (int i = 0; i < 200; i++)
            {
                context.Peoples.AsNoTracking().Any();
            }

            time.Stop();

            Console.WriteLine($"Tempo: {time.Elapsed}");
        }

        public static void ManageConnection(CustomContext context, bool manageConnectionState)
        {
            var time = Stopwatch.StartNew();

            var connection = context.Database.GetDbConnection();

            connection.StateChange += (_, _) => ++_count;

            if (manageConnectionState)
            {
                connection.Open();
            }

            for (int i = 0; i < 200; i++)
            {
                context.Sleeps.AsNoTracking().Any();
            }

            time.Stop();

            Console.WriteLine($"Tempo: {time.Elapsed}, Conexão Gerenciada: {manageConnectionState}, Contagem de Conexões: {_count}");
        }
    }
}
