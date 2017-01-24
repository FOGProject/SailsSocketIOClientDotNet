using System.Collections.Generic;
using FOG.SailsSocketIOClientDotNet;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace SailsSocketIOClientDotNet.Test
{
    [TestFixture]
    public class Headers
    {
        [Test]
        public void SetandReadGlobalHeader()
        {
            var client = Helper.GetClient();
            client.SetHeader("x-test-set", "foo");
            Assert.AreEqual("foo", client.GetHeader("x-test-set"));
            Assert.Pass();
        }

        [Test]
        public void DeleteGlobalHeader()
        {
            var client = Helper.GetClient();
            client.SetHeader("x-test-delete", "foo");
            client.RemoveHeader("x-test-delete");
            Assert.Throws<KeyNotFoundException>(() => client.GetHeader("x-test-delete"));
            Assert.Pass();
        }

        [Test]
        public void SendGlobalHeader()
        {
            var client = Helper.GetClient();
            client.SetHeader("x-foo-bar-global", "foobar");
            var response = client.Get("/test/headers/global", null).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());
            Assert.AreEqual("foobar", response.Body["fooBarHeader"].ToString());
            Assert.Pass();
        }

        [Test]
        public void SendLocalHeader()
        {
            var client = Helper.GetClient();
            var headers = new Dictionary<string, string> {{"x-foo-bar-local", "foobar"}};

            var response = client.Request("/test/headers/local", null, headers, SailsRequest.HTTPAction.get).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());
            Assert.AreEqual("foobar", response.Body["fooBarHeader"].ToString());
            Assert.Pass();
        }

        [Test]
        public void LocalHeadersOverrideGlobal()
        {
            var client = Helper.GetClient();
            client.SetHeader("x-foo-bar-override", "global");
            var headers = new Dictionary<string, string> { { "x-foo-bar-override", "local" } };

            var response = client.Request("/test/headers/override", null, headers, SailsRequest.HTTPAction.get).GetAwaiter().GetResult();
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(true, response.Body["success"].ToObject<bool>());
            Assert.AreEqual("local", response.Body["overrideHeader"].ToString());
            Assert.Pass();
        }

    }
}
