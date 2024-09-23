using EfCore.Core.DbContexts;
using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.Resilience
{
    public class ResilienceStrategy
    {
        public static void CreateStrategyResilience(CustomContext context)
        {
            UsinEnableRetryDoesntAffectCustomTransaction(context);
        }

        private static void UsinEnableRetryDoesntAffectCustomTransaction(CustomContext context)
        {
            using var transaction = context.Database.BeginTransaction();

            context.Dreams.Add(new Dream { CanPunch = true });
            context.SaveChanges();

            transaction.Commit();
        }

        private static void UsinEnableRetryForCustomTransaction(CustomContext context)
        {
            var strategy = context.Database.CreateExecutionStrategy();

            strategy.Execute(
            () =>
            {
                using var transaction = context.Database.BeginTransaction();

                context.Dreams.Add(new Dream { CanPunch = true });
                context.SaveChanges();

                transaction.Commit();

            });
        }
    }
}
