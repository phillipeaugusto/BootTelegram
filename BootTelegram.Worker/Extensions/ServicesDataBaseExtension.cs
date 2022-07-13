using System.Diagnostics.CodeAnalysis;
using BootTelegram.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BootTelegram.Worker.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesDataBaseExtension
    {
        public static void ServicesDataBaseInitialization(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnectionStr = configuration["ConnectionMySql:ConnectionString"];
            services.AddDbContext<DataContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)), ServiceLifetime.Singleton);
        }
    }
}