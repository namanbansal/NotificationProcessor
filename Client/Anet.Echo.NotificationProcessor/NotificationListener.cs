using Anet.Echo.Notifications;
using Anet.Echo.Notifications.WebHook;
using ANetNotificationDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Anet.Echo.NotificationProcessor
{
    public partial class NotificationListener : ServiceBase
    {
        private string notificationReceiveLocation;
        private int pollInterval;
        private Timer _timer;

        public NotificationListener()
        {
            InitializeComponent();
            notificationReceiveLocation = ConfigurationManager.AppSettings["NotificationReceiveLocation"];
            pollInterval = Convert.ToInt32(ConfigurationManager.AppSettings["PollInterval"]);

        }

        protected override void OnStart(string[] args)
        {
            //log.Info("Info - Service Started");
            _timer = new Timer(pollInterval * 1000); // every pollInterval seconds
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(readXMLNotifications);
            _timer.Start(); // <- important
            
        }

        protected override void OnStop()
        {
        }

        private void readXMLNotifications(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            var anetNotificationFiles = Directory.EnumerateFiles(notificationReceiveLocation, "*.xml");
            foreach (string anetNotificationFile in anetNotificationFiles)
            {
                XmlSerializer reader = new XmlSerializer(typeof(WebHookNotification));
                StreamReader file = new StreamReader(anetNotificationFile);
                WebHookNotification anetNotification = (WebHookNotification)reader.Deserialize(file);
                file.Close();
                WebHookNotificationHandler webhookHandler = new WebHookNotificationHandler();
                webhookHandler.Send(anetNotification);
                File.Delete(anetNotificationFile);
            }
            _timer.Start();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

    }
}
