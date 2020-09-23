using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SmokeTests_SupplyChain.PURCHASINGMVC
{
    class PurchaseOrdersPage
    {
        private IWebDriver _driver;
        private Utils utils;

        public PurchaseOrdersPage(IWebDriver driver)
        {
            this._driver = driver;
            driver.Navigate().GoToUrl("http://webbeta1.qg.com:8060/PurchasingMVC/PurchaseOrders/");
            utils = new Utils(driver);
        }

        public void LookupPO(int purchaseNumber)
        {
            _driver.FindElement(By.XPath
                ("//*[@id='pageNav']//a[@href='/PurchasingMVC/PurchaseOrders/Lookup']")).Click();
            _driver.FindElement(By.Id("PurchaseOrderNumber")).SendKeys
                (Convert.ToString(purchaseNumber));
            _driver.FindElement(By.Id("lookup")).Click();
            var headerText = _driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual($"Purchase Order { purchaseNumber }", headerText);
        }

        public VendorsPage GoToVendorTab()
        {
            _driver.FindElement(By.XPath
                ("//*[@id='siteNav']//a[@href='/PurchasingMVC/Vendors']")).Click();
            var headerText = _driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual("Vendors", headerText);
            return new VendorsPage(_driver);
        }

        public DashboardPage GoToDashboardTab()
        {
            _driver.FindElement(By.XPath
                ("//*[@id='siteNav']//a[@href='/PurchasingMVC/Dashboard/POManagerDashboard']")).Click();
            var headerText = _driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual("PO Dashboard", headerText);
            return new DashboardPage(_driver);
        }

        protected void OpenSearchTable()
        {
            _driver.FindElement(By.XPath("//*[@id='search_options']/h3/a")).Click();
            utils.WaitForAjaxComplete(3);
        }

        public void SearchForPoByEmploee(string employeeName)
        {
            //todo
        }
    }
}
