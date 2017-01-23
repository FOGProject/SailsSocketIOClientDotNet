using Newtonsoft.Json.Linq;

namespace FOG.SailsSocketIOClientDotNet
{
    public class SailsResponse
    {
        public JObject Raw { get; private set; }
        public string RawBody { get; private set; }
        public string RawHeaders { get; private set; }

        public JObject Body { get; private set; }
        public JObject Headers { get; private set; }

        public int StatusCode { get; private set; }



        public SailsResponse(dynamic rawResponse)
        {
            Raw = rawResponse;
            RawBody = rawResponse.body?.ToString();
            RawHeaders = rawResponse.headers?.ToString();

            StatusCode = (Raw["statusCode"] == null) ? 200 : int.Parse(rawResponse.statusCode.ToString());

            // Try to parse the header and body
            Body = (RawBody == null) ? new JObject() : JObject.Parse(RawBody); 
            Headers = (RawHeaders == null) ? new JObject() : JObject.Parse(RawHeaders);

        }
    }
}
