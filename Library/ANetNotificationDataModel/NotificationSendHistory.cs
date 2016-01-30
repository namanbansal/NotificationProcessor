using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class NotificationSendHistory : AnetBaseDataObject
    {
        [DataMember]
        public Guid NotificationId { get; set; }

        [DataMember]
        public DateTime TriedTime { get; set; }

        [DataMember]
        public int RetryCount { get; set; }
    }
}
