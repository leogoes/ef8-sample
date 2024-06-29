using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_PRIMARY_HOST") ?? throw new MissingFieldException("Missing Environment: DB_PRIMARY_HOST");

Console.WriteLine(connectionString);

builder.Services.AddDbContext<CustomContext>(x =>
    x.UseMySql(ServerVersion.AutoDetect(connectionString), options =>
    {
        options.EnableRetryOnFailure();
    })
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
);

IHost host = builder.Build();
host.Run();