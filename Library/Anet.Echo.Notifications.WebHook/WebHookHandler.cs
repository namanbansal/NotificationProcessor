using System;
using System.Collections.Generic;
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
    public class WebHookHandler
    {
        internal const string SignatureHeaderKey = "sha256";
        internal const string SignatureHeaderValueTemplate = SignatureHeaderKey + "={0}";
        internal const string SignatureHeaderName = "ms-signature";

        private const string BodyIdKey = "Id";
        private const string BodyAttemptKey = "Attempt";
        private const string BodyPropertiesKey = "Properties";
        private const string BodyNotificationsKey = "Notifications";


        public async Task SendWebHook(WebHookWorkItem workItem)
        {
            try
            {
                // Setting up and send WebHook request 
                HttpRequestMessage request = createWebHookRequest(workItem);
                HttpClient _httpClient = new HttpClient();
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == HttpStatusCode.Gone)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private HttpRequestMessage createWebHookRequest(WebHookWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("workItem");
            }

            WebHook hook = workItem.WebHook;

            // Create WebHook request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, hook.WebHookUri);

            // Fill in request body based on WebHook and work item data
            JObject body = createWebHookRequestBody(workItem);
            if (workItem.WebHook.Secret != null)
            {
                signWebHookRequest(workItem, request, body);
            }
            else
            {
                string serializedBody = body.ToString();
                request.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

            }


            // Add extra request or entity headers
            foreach (var kvp in hook.Headers)
            {
                if (!request.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value))
                {
                    if (!request.Content.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value))
                    {
                        string msg;// = string.Format(CultureInfo.CurrentCulture, CustomResources.Manager_InvalidHeader, kvp.Key, hook.Id);
                        //_logger.Error(msg);
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Creates a <see cref="JObject"/> used as the <see cref="HttpRequestMessage"/> entity body for a <see cref="WebHook"/>.
        /// </summary>
        /// <param name="workItem">The <see cref="WebHookWorkItem"/> representing the data to be sent.</param>
        /// <returns>An initialized <see cref="JObject"/>.</returns>
        private JObject createWebHookRequestBody(WebHookWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("workItem");
            }

            Dictionary<string, object> body = new Dictionary<string, object>();

            // Set properties from work item
            body[BodyIdKey] = workItem.Id;
            body[BodyAttemptKey] = workItem.Offset + 1;

            // Set properties from WebHook
            IDictionary<string, object> properties = workItem.WebHook.Properties;
            if (properties != null)
            {
                body[BodyPropertiesKey] = new Dictionary<string, object>(properties);
            }

            // Set notifications
            body[BodyNotificationsKey] = workItem.Notifications;

            return JObject.FromObject(body);
        }

        private void signWebHookRequest(WebHookWorkItem workItem, HttpRequestMessage request, JObject body)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("workItem");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            byte[] secret = Encoding.UTF8.GetBytes(workItem.WebHook.Secret);
            using (var hasher = new HMACSHA256(secret))
            {
                string serializedBody = body.ToString();
                request.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

                byte[] data = Encoding.UTF8.GetBytes(serializedBody);
                byte[] sha256 = hasher.ComputeHash(data);
                string headerValue = string.Format(CultureInfo.InvariantCulture, SignatureHeaderValueTemplate, EncodingUtilities.ToHex(sha256));
                request.Headers.Add(SignatureHeaderName, headerValue);
            }
        }
    }
}
