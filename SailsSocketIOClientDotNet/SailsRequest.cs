using Newtonsoft.Json.Linq;

namespace FOG.SailsSocketIOClientDotNet
{
    public class SailsRequest
    {
        public enum HTTPAction
        {
            get,
            post,
            put,
            delete
        }

        public string URL;
        public HTTPAction Method;
        public JObject Headers;
        public JObject Data;

        public JObject ToJSON()
        {
            var obj = new JObject
            {
                ["url"] = URL,
                ["method"] = Method.ToString(),
                ["headers"] = Headers,
                ["params"] = Data
            };
            return obj;
        }
    }
}
