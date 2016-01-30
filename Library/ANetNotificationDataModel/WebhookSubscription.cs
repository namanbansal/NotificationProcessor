using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ANetNotificationDataModel
{
    [DataContract]
    public class WebhookSubscription : NotificationSubscription
    {

        [DataMember]
        public Uri CallbackUrl { get; set; }

        [DataMember]
        public byte[] SecretKey { get; set; }
    }
}
