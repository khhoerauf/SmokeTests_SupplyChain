using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SmokeTests_SupplyChain.PURCHASINGMVC
{
    class VendorsPage
    {
        private IWebDriver _driver;
        private Utils utils;

        public VendorsPage(IWebDriver driver)
        {
            this._driver = driver;
            utils = new Utils(driver);
        }

        protected By vendorSearchbox = By.XPath("//input[@id='SearchText']");
        protected By tableResult = By.XPath("//tr/td");
        protected By vendorCodeHyperlink = By.XPath("//tr/td/a");
        protected By searchButton = By.Id("search");
        protected By onTimeDeliveryRevisedDateLink = By.CssSelector("a.LateDeliveryDetailPageLink");
        protected By onTimeDeliveryOriginalDateLink = By.CssSelector("a.LateDeliveryDetailPageLinkOriginalDueDate");

        public void SearchForVendor(string searchValue)
        {
            _driver.FindElement(vendorSearchbox).Click();
            _driver.FindElement(vendorSearchbox).Clear();
            _driver.FindElement(vendorSearchbox).SendKeys(searchValue);
            _driver.FindElement(searchButton).Click();
            utils.WaitForAjaxComplete(5);
        }

        public void GetFirstSearchResultAndVerify(string searchValue)
        {
            CompareExpectedCountWithActualCountResults(1);
            string vendrCode = _driver.FindElement(vendorCodeHyperlink).Text;
            Assert.AreEqual(searchValue, vendrCode);
        }

        public void GetEmptySearchResultAndVerify()
        {
            string vendrCode = _driver.FindElement(tableResult).Text;
            Assert.AreEqual("No data available in table", vendrCode);
        }

        public void SelectSearchFilterContains()
        {
            _driver.FindElements(By.XPath("//*[@id='ContainsSearch']"))[0].Click();
        }

        public void SelectSearchFilterStartWith()
        {
            _driver.FindElements(By.XPath("//*[@id='ContainsSearch']"))[1].Click();
        }

        protected int CountSearchResults()
        {
            IList<string> all = new List<string>();

            foreach (var element in _driver.FindElements(By.XPath("//tbody/tr")))
            {
                all.Add(element.Text);
            }
            return all.Count;
        }

        public void CompareExpectedCountWithActualCountResults(int expectedResult)
        {
            int countResult = CountSearchResults();
            Assert.AreEqual(expectedResult, countResult);
        }

        public void VerifyIfResultsAreGreaterThan(int greaterThan)
        {
            int countResult = CountSearchResults();
            Assert.Greater(countResult, greaterThan, "Fail - expected to return more search results");
        }
    }
}

