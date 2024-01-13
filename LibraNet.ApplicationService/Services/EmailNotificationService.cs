using LibraNet.Contracts.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Services.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;

        public EmailNotificationService(ILogger<EmailNotificationService> logger)
        {
            _logger = logger;
        }

        public void SendDayAfterNotification()
        {
            throw new NotImplementedException();
        }

        public void SendDayBeforeNotification()
        {
            throw new NotImplementedException();
        }
    }
}
