using EfCore.Core.DataLoadTypes;
using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

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

builder.Services.AddDbContext<CustomContext>(x =>
    x.UseMySql(connectionString, serverVersion, options =>
    {
        options.EnableRetryOnFailure();
    })
    .LogTo(Console.WriteLine, LogLevel.Information)
    //.UseLazyLoadingProxies()
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
);

IHost host = builder.Build();

var context = host.Services.GetRequiredService<CustomContext>();

await LazyLoading.Load(context);

host.Run();

