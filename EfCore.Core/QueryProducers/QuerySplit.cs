using EfCore.Core.DbContexts;
using EfCore.Core.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Core.QueryProducers
{
    public class QuerySplit
    {
        public static void SplitQuery(CustomContext context)
        {
            context.Dreams.Include(x => x.Peoples)
                          .AsSplitQuery()
                          .ToList();
        }

        public static void DisableSplitQuery(IQueryable<IEntity> query)
        {
            query.AsSingleQuery();
        }

        public static MySqlDbContextOptionsBuilder GlobalSpliQuery(MySqlDbContextOptionsBuilder options) => 
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }
}
