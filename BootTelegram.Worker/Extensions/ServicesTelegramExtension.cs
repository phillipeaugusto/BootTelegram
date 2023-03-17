using System.Diagnostics.CodeAnalysis;
using BootTelegram.Infrastructure.Services.Telegram;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BootTelegram.Worker.Extensions;

[ExcludeFromCodeCoverage]
public static class ServicesTelegramExtension
{
    public static void ServicesTelegramInitialization(this IServiceCollection services, IConfiguration configuration)
    {
        var apiHash = configuration["TelegramConfig:ApiHash"];
        var apiId = configuration["TelegramConfig:ApiId"]; 
        var phoneNumber = configuration["TelegramConfig:PhoneNumber"];
        var password = configuration["TelegramConfig:Password"];
        var firstName = configuration["TelegramConfig:FirstName"];
        var lastName = configuration["TelegramConfig:LastName"];
        var verificationCode = configuration["TelegramConfig:VerificationCode"];
            
        var telegramConfig = new TelegramConfig
        {
            ApiHash =  apiHash,
            ApiId = apiId, 
            PhoneNumber = phoneNumber, 
            Password = password, 
            FirstName = firstName,
            LastName = lastName, 
            VerificationCode = verificationCode
        };

        services.AddSingleton(telegramConfig);
    }
}