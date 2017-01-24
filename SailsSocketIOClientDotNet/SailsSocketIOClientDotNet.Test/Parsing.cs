using NUnit.Framework;

namespace SailsSocketIOClientDotNet.Test
{
    [TestFixture]
    public class Parsing
    {
        [Test]
        public void GoodBodyFormat()
        {
            var client = Helper.GetClient();
            var response = client.Get("/test/goodFormat", null).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());

            Assert.Pass();
        }

        [Test]
        public void BadBodyFormat()
        {
            var client = Helper.GetClient();
            var response = client.Get("/test/badFormat", null).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("Not JSON", response.RawBody);
            Assert.AreEqual(0, response.Body.Count);
            Assert.Pass();
        }

        [Test]
        public void StatusCode()
        {
            var client = Helper.GetClient();
            var response = client.Get("/test/unauthorized", null).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(403, response.StatusCode);
            Assert.AreEqual(0, response.Body.Count);

            Assert.Pass();
        }

    }
}
