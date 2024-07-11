using EfCore.Core.ConnectionManagements;
using EfCore.Core.DbContexts;
using EfCore.Core.RawSqls;
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
           .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Information)
           .Enrich.WithProperty("app", "Sample")
           .Enrich.FromLogContext()
           .CreateLogger();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 38));

builder.Services.AddDbContext<CustomContext>(x =>
    x.UseMySql(connectionString, serverVersion, options =>
    {
        options.EnableRetryOnFailure();
    })
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
);

IHost host = builder.Build();

var context = host.Services.GetRequiredService<CustomContext>();

ExecuteRawSql.Execute(context);

host.Run();

