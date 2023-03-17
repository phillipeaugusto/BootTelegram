using System;
using System.Diagnostics.CodeAnalysis;
using BootTelegram.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BootTelegram.Worker.Extensions;

[ExcludeFromCodeCoverage]
public static class ServicesDataBaseExtension
{
    public static void ServicesDataBaseInitialization(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = !string.IsNullOrEmpty(configuration["ConnectionDb:ConnectionString"]) ? configuration["ConnectionDb:ConnectionString"] : Environment.GetEnvironmentVariable("ConnectionStringDb");
        services.AddDbContext<DataContext>(options => options.UseNpgsql(connection!), ServiceLifetime.Singleton);
    }
}