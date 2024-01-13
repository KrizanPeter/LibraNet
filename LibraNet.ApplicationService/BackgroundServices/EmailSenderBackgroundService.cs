using System;
using System.Threading;
using System.Threading.Tasks;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.BackgroundServices
{
    public class EmailSenderBackgroundService : BackgroundService
    {
        private readonly IHostEnvironment _environment;
        private readonly IEmailNotificationService _emailNotificationService;
        public ILogger<EmailSenderBackgroundService> _logger { get; }


        public EmailSenderBackgroundService(ILogger<EmailSenderBackgroundService> logger,
            IHostEnvironment environment, 
            IEmailNotificationService emailNotificationService )
        {
            _logger = logger;
            _environment = environment;
            _emailNotificationService = emailNotificationService;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _emailNotificationService.SendDayBeforeNotification();
                    _emailNotificationService.SendDayAfterNotification();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Notification service failed: " + ex.Message);
                }

                Console.WriteLine($"Task is running at {DateTime.Now}.");

                //just for testing purpose than every 24 hours
                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}