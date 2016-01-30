using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class WebHookNotification : Notification
    {
        [DataMember]
        [XmlIgnore]
        public Uri CallbackUrl { get; set; }

        [XmlElement("CallbackUrl")]
        public string serializableUri
        {
            get { return CallbackUrl.ToString(); }
            set { CallbackUrl = new Uri(value); }
        }

        [DataMember]
        public byte[] SecretKey { get; set; }
    }
}
