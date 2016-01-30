using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Anet.Echo.Harness.WebClient
{
    public class WebHookNotificationBAL
    {
        private static string connectionString = WebConfigurationManager.AppSettings["ConnectionString"];

        public static void WebhookData(JToken jsonBody)
        {
            string sqlQuery = "Insert INTO WebhookNotification(WebhookId, Payload, ReceivedOn) Values ('" + jsonBody["Id"] + "' ,'" + jsonBody["Notifications"] + "' ,'" + DateTime.Now + "')";

            int rows = WriteToDb(connectionString, sqlQuery);
            
        }

        //To write to DB
        public static int WriteToDb(string connectionString, string sqlQuery)
        {
            SqlDatabase db = new SqlDatabase(connectionString);

            DbCommand cmd = db.GetSqlStringCommand(sqlQuery);

            //return the number of rows affected
            return db.ExecuteNonQuery(cmd);
        }

        public static IDataReader GetIDataReader(string connectionString, string sqlQuery)
        {
            SqlDatabase sqlServerDB = new SqlDatabase(connectionString);
            DbCommand cmd = sqlServerDB.GetSqlStringCommand(sqlQuery);
            //return an IDataReader.
            return sqlServerDB.ExecuteReader(cmd);
        }
    }
}