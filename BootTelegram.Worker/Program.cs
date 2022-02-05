using BootTelegram.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BootTelegram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
       
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.ServicesDataBaseInitialization(hostContext.Configuration);
                    services.ServicesInitialization();
                    services.ServicesTelegramInitialization(hostContext.Configuration);
                    services.AddHostedService<Worker>();
                });
    }
}