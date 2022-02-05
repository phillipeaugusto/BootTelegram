using System.Diagnostics.CodeAnalysis;
using BootTelegram.Application.Services;
using BootTelegram.Domain.Repositories;
using BootTelegram.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BootTelegram.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesExtension
    {
        public static void ServicesInitialization(this IServiceCollection services)
        {
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IReadingRepository, ReadingRepository>();
            services.AddTransient<IDictionaryDataRepository, DictionaryDataRepository>();

            services.AddTransient<GroupService, GroupService>();
            services.AddTransient<ReadingService, ReadingService>();
            services.AddTransient<MessageHandlingService, MessageHandlingService>();
        }
    }
}