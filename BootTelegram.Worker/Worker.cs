using System;
using System.Threading;
using System.Threading.Tasks;
using BootTelegram.Application.Services;
using BootTelegram.Infrastructure.Services.Telegram;
using BootTelegram.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BootTelegram
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private GroupService _groupService;
        private ReadingService _readingService;
        private MessageHandlingService _messageHandlingService;
        private TelegramConfig _telegramConfig;
        
        public Worker(ILogger<Worker> logger, 
            [FromServices] GroupService groupService, 
            [FromServices] ReadingService readingService, 
            [FromServices] MessageHandlingService messageHandlingService, 
            [FromServices] TelegramConfig telegramConfig)
        {
            _logger = logger;
            _groupService = groupService;
            _readingService = readingService;
            _telegramConfig = telegramConfig;
            _messageHandlingService = messageHandlingService;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Initializing Worker - {RequestTime} ", DateTime.Now);
            await new WorkerTelegram(_logger, _groupService, _readingService, _messageHandlingService, _telegramConfig).ExecuteAsync();
        }
    }
}
