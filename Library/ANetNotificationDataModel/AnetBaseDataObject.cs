using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class AnetBaseDataObject : IExtensibleDataObject
    {
        [DataMember]
        public ExtensionDataObject ExtensionData { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }
    }
}
