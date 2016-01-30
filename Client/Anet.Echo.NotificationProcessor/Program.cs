using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Anet.Echo.NotificationProcessor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //if (Environment.UserInteractive)
            //{
            //    NotificationListener service1 = new NotificationListener();
            //    string[] args = new string[10];
            //    service1.TestStartupAndStop(args);
            //}
            //else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new NotificationListener() 
            };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
