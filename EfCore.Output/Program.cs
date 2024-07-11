using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_PRIMARY_HOST") ?? throw new MissingFieldException("Missing Environment: DB_PRIMARY_HOST");

Console.WriteLine(connectionString);

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

host.Run();

