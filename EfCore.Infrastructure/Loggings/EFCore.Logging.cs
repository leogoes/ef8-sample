using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EfCore.Infrastructure.Loggings
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
    }
}
