using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Services
{
    public interface IEmailNotificationService
    {
        void SendDayBeforeNotification();
        void SendDayAfterNotification();
    }
}
