
using BootTelegram.Extensions;
using BootTelegram.Worker.Extensions;
using BootTelegram.Worker.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.ServicesDataBaseInitialization(hostContext.Configuration);
        services.ServicesInitialization();
        services.ServicesTelegramInitialization(hostContext.Configuration);
        services.AddHostedService<WorkerTelegram>();
    })
    .Build();

await host.RunAsync();