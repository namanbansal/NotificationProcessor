using ANetNotificationDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anet.Echo.Notifications
{
    public interface INotificationHandler
    {
        void Send(Notification notification);
    }
}
