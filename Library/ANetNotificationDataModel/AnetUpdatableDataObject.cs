using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class AnetUpdatableDataObject : AnetBaseDataObject
    {
        [DataMember]
        public DateTime UpdatedDate { get; set; }

        [DataMember]
        public Guid UpdatedBy { get; set; }

        [DataMember]
        public byte[] VersionNumber { get; set; } // corresponds to sql timestamp and use for stale data handling.
    }
}
