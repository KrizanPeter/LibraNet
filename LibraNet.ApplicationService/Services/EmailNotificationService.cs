using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly ILogger<EmailNotificationService> _logger;
        private readonly IBorrowingService _borrowingService;
        private readonly IBorrowingRepository _borrowingRepository;

        public EmailNotificationService(ILogger<EmailNotificationService> logger,
            IBorrowingService borrowingService, 
            IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
            _borrowingService = borrowingService;
            _logger = logger;
        }

        public void SendDayAfterNotification()
        {
            throw new NotImplementedException();
        }

        public async void SendDayBeforeNotification()
        {
            _logger.LogInformation($"Sending notification emails {DateTime.UtcNow}");
            
            
            var borrowings = await _borrowingRepository
                .GetAllAsync(a=>a.Status == Contracts.Enums.BorrowingStatus.Active 
                && a.BorrowingTo <= DateTime.UtcNow.AddDays(1));

            if (borrowings == null)
            {
                return;
            }

            foreach(var borrowing in borrowings)
            {
                // send mail
            }
        }
    }
}
