using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.QueryProducers
{
    public class QueryTags
    {
        public static void QueryWithTags(CustomContext context)
        {
            context.Dreams.TagWith("Dream Search").ToList();
        }
    }
}
