using Anet.Echo.Notifications;
using ANetNotificationDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace Anet.Echo.Harness.NotificationManager
{
    public partial class Manager : Form
    {
        private string notificationReceiveLocation;
        private int fileNumber = 0;

        public Manager()
        {
            InitializeComponent();
            notificationReceiveLocation = ConfigurationManager.AppSettings["NotificationReceiveLocation"];

        }

        private void btnPushWebHookNotification_Click(object sender, EventArgs e)
        { 
            WebHookNotification sampleNotification = new WebHookNotification { CreatedBy = Guid.NewGuid() , CreatedDate = DateTime.Now, CallbackResponse =  "ANetNotification Manager" + DateTime.Now.TimeOfDay, NotificationPriority = Priority.Normal, CallbackUrl= new Uri("http://localhost:55950/api/webhooks")};

            try
            {
                var writer = new XmlSerializer(typeof(WebHookNotification));
                var wfile = new StreamWriter(notificationReceiveLocation + @"\ANetNotification_" + fileNumber.ToString() + ".xml");
                writer.Serialize(wfile, sampleNotification);
                wfile.Close();
                fileNumber = fileNumber + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            //WebHookNotificationHandler webHookHandler = new WebHookNotificationHandler();
            //WebHookNotification webhookNotification = new WebHookNotification() { CallbackUrl = new Uri("http://requestb.in/135tyxp1") };
            //WebHookNotification webhookNotification = new WebHookNotification() { CallbackUrl = new Uri("http://localhost:55950/api/webhooks") };

            //webHookHandler.Send(webhookNotification);
        }
    }
}
