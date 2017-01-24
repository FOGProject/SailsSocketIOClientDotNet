using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace SailsSocketIOClientDotNet.Test
{
    [TestFixture]
    public class Actions
    {
        private readonly JObject _payload = new JObject { ["foo"] = "bar" };

        [Test]
        public void Get()
        {
            var client = Helper.GetClient();
            var response = client.Get("/test/normal", _payload).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("get", response.Body["method"].ToString());
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());

            Assert.Pass();
        }

        [Test]
        public void Post()
        {
            var client = Helper.GetClient();
            var response = client.Post("/test/normal", _payload).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("post", response.Body["method"].ToString());
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());

            Assert.Pass();
        }

        [Test]
        public void Put()
        {
            var client = Helper.GetClient();
            var response = client.Put("/test/normal", _payload).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("put", response.Body["method"].ToString());
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());

            Assert.Pass();
        }

        [Test]
        public void Delete()
        {
            var client = Helper.GetClient();
            var response = client.Delete("/test/normal", _payload).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("delete", response.Body["method"].ToString());
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());

            Assert.Pass();
        }
    }
}
