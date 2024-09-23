using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EfCore.Core.Loggings
{
    public static class EFCoreLogging
    {
        public static DbContextOptionsBuilder CustomLogTo(this DbContextOptionsBuilder builder)
        {
            return builder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public static DbContextOptionsBuilder FilterLogByEvents(this DbContextOptionsBuilder builder)
        {
            return builder.LogTo(
                    Console.WriteLine,
                    new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
                    LogLevel.Information,
                    DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine
            );
        }

        public static DbContextOptionsBuilder WriteLogToFile(this DbContextOptionsBuilder builder, StreamWriter writer)
        {
            return builder.LogTo(writer.WriteLine, LogLevel.Debug);
        }

        /// <summary>
        /// <see href="https://learn.microsoft.com/pt-br/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder.enabledetailederrors?view=efcore-8.0"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder EnableDetailedErrors(this DbContextOptionsBuilder builder)
        {
            return builder.EnableDetailedErrors();
        }

        /// <summary>
        /// <see href="https://learn.microsoft.com/pt-br/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder.enablesensitivedatalogging?view=efcore-8.0"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder EnableSensitiveDataLogging(this DbContextOptionsBuilder builder)
        {
            return builder.EnableSensitiveDataLogging();
        }
    }
}
