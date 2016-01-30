using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class EmailSubscription : NotificationSubscription
    {
        [DataMember]
        public string EmailAddress { get; set; }
    }
}
