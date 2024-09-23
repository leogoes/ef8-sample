using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Core.Timeouts
{
    public static class CustomTimeout
    {
        public static void ChangeDefaultTimeout(this MySqlDbContextOptionsBuilder builder, int timeout)
        {
            builder.CommandTimeout(timeout);
        }
    }
}
