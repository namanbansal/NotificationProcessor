using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class Subscriber : AnetUpdatableDataObject
    {
        [DataMember]
        public Guid SubscriberId { get; set; }

        [DataMember]
        public string ExternalUserId { get; set; }

        [DataMember]
        public string SystemUserId { get; set; }

        [DataMember]
        public string UserType { get; set; }
    }
}
