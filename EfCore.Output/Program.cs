using EfCore.Core.DataLoadTypes;
using EfCore.Core.DbContexts;
using EfCore.Core.QueryProducers;
using EfCore.Core.StoreProcedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using EfCore.Infrastructure.Loggings;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_PRIMARY_HOST") ?? throw new MissingFieldException("Missing Environment: DB_PRIMARY_HOST");

Console.WriteLine(connectionString);

builder.Logging.Services.AddSerilog();

Log.Logger = new LoggerConfiguration()
           .Enrich.WithProperty("app", "Sample")
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .CreateLogger();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

CreateContextSampleA(builder, connectionString, serverVersion);

IHost host = builder.Build();

var context = host.Services.GetRequiredService<ContextSampleA>();

var dream = await context.Dreams.FirstOrDefaultAsync();

host.Run();

static void CreateCustomContext(HostApplicationBuilder builder, string connectionString, MySqlServerVersion serverVersion)
{
    builder.Services.AddDbContext<CustomContext>(x =>
        x.UseMySql(connectionString, serverVersion, options =>
        {
            options.EnableRetryOnFailure();
        })
        .CustomLogTo()
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging());
}

static void CreateContextSampleA(HostApplicationBuilder builder, string connectionString, MySqlServerVersion serverVersion)
{
    builder.Services.AddDbContext<ContextSampleA>();
}
