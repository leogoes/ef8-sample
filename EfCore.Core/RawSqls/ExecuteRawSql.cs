using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.RawSqls
{
    public class ExecuteRawSql
    {
        public static void Execute(CustomContext context)
        {
            var connection = context.Database.GetDbConnection();

            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = "SELECT 1";
            command.ExecuteNonQuery();
        }
    }
}
