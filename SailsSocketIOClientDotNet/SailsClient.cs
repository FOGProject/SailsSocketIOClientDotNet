using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace FOG.SailsSocketIOClientDotNet
{
    // Modeled after https://github.com/balderdashy/sails.io.js/blob/master/sails.io.js
    public class SailsClient
    {
        private const string DefaultVersion = "0.13.8";
        private const string DefaultLanguage = "csharp";
        private const string DefaultPlatform = "desktop";

        public Socket Socket { get; private set; }

        public SailsClient(string url, SDKInfo sdkInfo = null)
        {
            if (sdkInfo == null)
                sdkInfo = new SDKInfo(DefaultVersion, DefaultLanguage, DefaultPlatform);

            var options = new IO.Options {QueryString = sdkInfo.VersionString};
            Socket = IO.Socket(url, options);
        }

        private async Task<dynamic> _emitFrom(SailsRequest request)
        {
            var autoResetEvent = new AsyncAutoResetEvent();
            dynamic response = null;

            Socket.Emit(request.Method.ToString(), new AckImpl((data) =>
            {
                response = data;
                autoResetEvent.Set();

            }), request.ToJSON());
            await autoResetEvent.WaitAsync();
            return response;
        }

        public async Task<SailsResponse> Request(string url, JObject data, JObject headers, SailsRequest.HTTPAction method)
        {
            // Default data and headers to empty objects
            if (data == null) data = new JObject();
            if (headers == null) headers = new JObject();

            // Remove trailing slashes and spaces to make packets smaller
            url = Regex.Replace(url, @"/^(.+)\/*\s*$/", "$1");
            var request = new SailsRequest { 
                Data = data,
                Headers = headers,
                Method = method,
                URL = url
            };
            var rawResponse =  await _emitFrom(request);
            return new SailsResponse(rawResponse);
        }

        public async Task<SailsResponse> Get(string url, JObject data)
        {
            return await Request(url, data, null, SailsRequest.HTTPAction.get);
        }

        public async Task<SailsResponse> Post(string url, JObject data)
        {
            return await Request(url, data, null, SailsRequest.HTTPAction.post);
        }

        public async Task<SailsResponse> Put(string url, JObject data)
        {
            return await Request(url, data, null, SailsRequest.HTTPAction.put);
        }

        public async Task<SailsResponse> Delete(string url, JObject data)
        {
            return await Request(url, data, null, SailsRequest.HTTPAction.delete);
        }

    }
}
