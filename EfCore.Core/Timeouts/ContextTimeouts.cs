using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.Timeouts
{
    public static class ContextTimeouts
    {
        public static void SimulateTimeout(CustomContext context)
        {
            context.Database.ExecuteSqlRaw("WAITFOR DELAY '00:00:07'; SELECT 1");
        }

        public static void IncreaseTimeoutForSpecificQuery(CustomContext context, int timeout)
        {
            context.Database.SetCommandTimeout(timeout);
        }
    }
}
