using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ANetNotificationDataModel
{
    [DataContract]
    public enum Priority
    {
        // None = 0, // do not use this to avoid default values.
        High = 1,
        Normal = 5,
        Low = 9,
    }
}
