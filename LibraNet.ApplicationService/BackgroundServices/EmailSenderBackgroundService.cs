using System;
using System.Threading;
using System.Threading.Tasks;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.BackgroundServices
{
    public class EmailSenderBackgroundService : BackgroundService
    {
        private readonly IHostEnvironment _environment;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EmailSenderBackgroundService(IServiceScopeFactory serviceScopeFactory, IHostEnvironment environment )
        {
            _serviceScopeFactory = serviceScopeFactory;
            _environment = environment;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailNotificationService>();
                        emailService.SendDayAfterNotification();
                        emailService.SendDayBeforeNotification();
                    }
                }
                catch (Exception ex)
                {
                    //some logging
                }

                Console.WriteLine($"Task is running at {DateTime.UtcNow}.");

                //just for testing purpose than every 24 hours
                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}