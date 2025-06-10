using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnowflakeTestApp.Tests
{
    /// <summary>
    /// Integration tests for the /dataset endpoint.
    /// These tests document the expected behavior and can be used to verify the endpoint manually.
    /// </summary>
    [TestClass]
    public class DatasetEndpointIntegrationTest
    {

        /// <summary>
        /// This test shows how to manually test the endpoint if the application is running
        /// To run this test:
        /// 1. Start the SnowflakeTestApp application
        /// 2. Run this test
        /// </summary>
        [TestMethod]
        public async Task DatasetEndpointTest()
        {
            var baseUrl = "https://localhost:44362";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml")
            );

            try
            {
                var response = await client.GetAsync($"{baseUrl}/datasets");
                Assert.IsTrue(response.IsSuccessStatusCode, $"Expected success but got {response.StatusCode}");
                
                var content = await response.Content.ReadAsStringAsync();
                Assert.IsFalse(string.IsNullOrEmpty(content), "Response content should not be empty");
                
                var xmlDoc = XDocument.Parse(content);

                var dataSetElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "DataSet");
                Assert.IsNotNull(dataSetElement, "Could not find DataSet element in response");

                var displayNameElement = dataSetElement.Elements().First(e => e.Name.LocalName == "DisplayName");
                Assert.AreEqual("dataset", displayNameElement.Value);

                var nameElement = dataSetElement.Elements().First(e => e.Name.LocalName == "Name");
                Assert.AreEqual("default", nameElement.Value);

                var tablesElement = dataSetElement.Elements().FirstOrDefault(e => e.Name.LocalName == "tables");
                Assert.IsNotNull(tablesElement, "tables element should exist");
                Assert.AreEqual(0, tablesElement.Elements().Count());    
            }
            finally
            {
                client.Dispose();
            }
        }
    }
} 