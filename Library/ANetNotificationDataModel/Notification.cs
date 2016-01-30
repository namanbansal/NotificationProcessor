using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public abstract class Notification : AnetUpdatableDataObject
    {
        [DataMember]
        public Guid NotificationId { get; set; }

        [DataMember]
        public Guid EventId { get; set; }

        [DataMember]
        public Guid SubscriberId { get; set; }

        [DataMember]
        public bool DeliveryStatus { get; set; }

        [DataMember]
        public int RetryCount { get; set; }

        [DataMember]
        public string CallbackResponse { get; set; }

        [DataMember]
        public Priority NotificationPriority { get; set; }

        [DataMember]
        public AnetApiPayload Payload { get; set; }
    }
}
