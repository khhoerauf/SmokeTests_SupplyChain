using OpenQA.Selenium;

namespace SmokeTests_SupplyChain.PURCHASINGMVC
{
    class DashboardPage
    {
        private IWebDriver _driver;
        private Utils utils;
        public DashboardPage(IWebDriver driver)
        {
            this._driver = driver;
            utils = new Utils(driver);
        }
    }
}
