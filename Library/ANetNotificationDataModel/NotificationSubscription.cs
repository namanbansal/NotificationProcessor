using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public abstract class NotificationSubscription : AnetUpdatableDataObject
    {
        [DataMember]
        public Guid SubscriptionId { get; set; }

        [DataMember]
        public List<Guid> EventTypeIds { get; set; }

        [DataMember]
        public Guid SubscriberId { get; set; }
    }
}
