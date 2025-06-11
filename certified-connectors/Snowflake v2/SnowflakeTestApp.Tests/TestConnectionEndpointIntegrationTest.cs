using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnowflakeTestApp.Tests
{
    /// <summary>
    /// Integration tests for the /testconnection endpoint.
    /// These tests document the expected behavior and can be used to verify the endpoint manually.
    /// </summary>
    [TestClass]
    public class TestConnectionEndpointIntegrationTest : BaseIntegrationTest
    {
        /// <summary>
        /// This test shows how to manually test the endpoint with authentication if the application is running
        /// To run this test:
        /// 1. Start the SnowflakeTestApp application
        /// 2. Create a test-secrets.json file in the test directory with your bearer token
        /// 3. Run this test
        /// </summary>
        [TestMethod]
        public async Task TestConnectionEndpoint_WithAuth_ReturnsOk()
        {
            var testToken = GetTestToken();
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {testToken}");

            var response = await HttpClient.GetAsync($"{BaseUrl}/testconnection");
            Assert.IsTrue(response.IsSuccessStatusCode, $"Expected success but got {response.StatusCode}");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Expected HTTP 200 OK status code");
        }

        /// <summary>
        /// This test verifies that the testconnection endpoint requires authentication
        /// </summary>
        [TestMethod]
        public async Task TestConnectionEndpoint_WithoutAuth_ReturnsUnauthorized()
        {
            var response = await HttpClient.GetAsync($"{BaseUrl}/testconnection");

            Assert.IsFalse(response.IsSuccessStatusCode, $"Expected failure but got {response.StatusCode}");
        }
    }
} 