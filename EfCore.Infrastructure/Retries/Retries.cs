using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Infrastructure.Retries
{
    public static class Retries
    {
        public static void CustomEnableRetryOnFailure(this MySqlDbContextOptionsBuilder builder)
        {
            builder.EnableRetryOnFailure(1, TimeSpan.FromSeconds(10), null);
        }
    }
}
