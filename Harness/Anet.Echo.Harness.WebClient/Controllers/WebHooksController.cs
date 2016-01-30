using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Anet.Echo.Harness.WebClient.Controllers
{
    public class WebHooksController : ApiController
    {
        // GET api/webhooks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/webhooks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/webhooks
        public string Post([FromBody]JToken jsonbody)
        {
            var val = jsonbody["Id"];
            WebHookNotificationBAL.WebhookData(jsonbody);
            return jsonbody.ToString();
        }

        // PUT api/webhooks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/webhooks/5
        public void Delete(int id)
        {
        }
    }
}
;