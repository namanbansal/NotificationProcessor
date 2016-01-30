using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using ANetNotificationDataModel;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;



namespace Anet.Echo.Notifications.WebHook
{
    public class WebHookNotificationHandler : INotificationHandler
    {        
        public void Send(Notification notification)
        {
            WebHookNotification webhookNotification = notification as WebHookNotification;
            if (webhookNotification == null)
            {
                throw new ArgumentException("Invalid type passed to web hook notification handler. Expected an instance of WebHookNotification.");
            }                        
            
            // Create Web Hook
            WebHook webhook = new WebHook();
            webhook.Description = webhookNotification.CallbackResponse;
            webhook.WebHookUri = webhookNotification.CallbackUrl;
            webhook.Id = "2";

            // Create Notification List (multiple notifications can be sent to the single web hook)
            List<NotificationDictionary> notificationList = new List<NotificationDictionary>();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "ID", webhookNotification.CreatedBy.ToString() },
                { "Created Date", webhookNotification.CreatedDate.ToString() },
            };
            notificationList.Add(new NotificationDictionary("customEvent", data));
            
            // Create a Work Item for processing the Web Hook
            WebHookWorkItem workItem = new WebHookWorkItem(webhook, notificationList);

            WebHookHandler webhookHandler = new WebHookHandler();
            webhookHandler.SendWebHook(workItem);
        }

        
    }
}
