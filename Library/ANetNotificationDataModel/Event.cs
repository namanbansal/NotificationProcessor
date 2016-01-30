using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    public class Event : AnetBaseDataObject
    {
        [DataMember]
        public Guid EventId { get; set; }

        [DataMember]
        public String EventTypeName { get; set; }

        [DataMember]
        public string EntityId { get; set; }

        [DataMember]
        public string ApplicationSource { get; set; }

        [DataMember]
        public Guid CorrelationId { get; set; }
    }
}
