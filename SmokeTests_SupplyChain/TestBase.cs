using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmokeTests_SupplyChain
{
    class TestBase
    {
        public IWebDriver Driver = new ChromeDriver(@"C:\Temp");

        static readonly HttpClient client = new HttpClient();

        public static async Task ServiceHealthyCheck(string healthyCheckCall)
        {
            var response = new HealthCheckResponse();

            try
            {   //need improvment 
                response.Description = await client.GetStringAsync(healthyCheckCall);
                string text = response.Description.Substring(response.Description.Length - 24);

                Assert.AreEqual("<hr />Service is healthy", text);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        [TearDown]
        public void CloseTest()
        {
            Driver.Quit();
        }
    }
}
