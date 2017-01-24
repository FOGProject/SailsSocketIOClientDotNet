using FOG.SailsSocketIOClientDotNet;

namespace SailsSocketIOClientDotNet.Test
{
    public static class Helper
    {
        private const string TestServer = "http://localhost:1337";
        private static SailsClient _client;

        public static SailsClient GetClient()
        {
            if(_client == null) _client = new SailsClient(TestServer);

            return _client;
        }
    }
}
