using EfCore.Core.DbContexts;
using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.QueryProducers
{
    public class QueryGlobalFilter
    {
        public static void AddGlobalFilter(ModelBuilder builder)
        {
            builder.Entity<Sleep>().HasQueryFilter(x => x.CountOfSheeps.Count() > 1);
        }


        public static IQueryable<Dream> IgnoreGlobalFilter(CustomContext context)
        {
            return context.Dreams.IgnoreQueryFilters();
        }
    }
}

