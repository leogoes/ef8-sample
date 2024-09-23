using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Core.BatchSize
{
    public static class CustomBatchSize
    {
        public static void ChangeDefaultBatchSize(this MySqlDbContextOptionsBuilder builder, int max, int min)
        {
            builder.MaxBatchSize(max);
            builder.MinBatchSize(min);
        }
    }
}
