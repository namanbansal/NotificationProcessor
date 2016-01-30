using System;
using System.Collections.Generic;

using System.Runtime.Serialization;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class EventType : AnetUpdatableDataObject
    {
        [DataMember]
        public Guid EventTypeId { get; set; }

        [DataMember]
        public string EventTypeName { get; set; }

        [DataMember]
        public Priority EventPriority { get; set; }
    }
}
