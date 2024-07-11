using EfCore.Core.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace EfCore.Core.HealthCheck
{
    public class MySqlHealthCheck
    {
        public static bool Healthy(CustomContext context)
        {
            return context.Database.CanConnect();
        }

        public async Task<bool> HealthyAsync(CustomContext context)
        {
            return await context.Database.CanConnectAsync();
        }

        public static void ConfigureHealthCheck(IServiceCollection services)
        {
            services.AddHealthChecks().AddDbContextCheck<CustomContext>("DB_CONTEXT_CHECK");
        }
    }
}
