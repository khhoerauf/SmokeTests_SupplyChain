using OpenQA.Selenium;
using System;

namespace SmokeTests_SupplyChain
{
    public class Utils
    {
        protected IWebDriver Driver { get; }

        public Utils(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void WaitForAjaxComplete(int maxSeconds)
        {
            bool is_ajax_compete = false;
            for (int i = 1;
                i <= maxSeconds;
                i++)
            {
                is_ajax_compete =
                    (bool)((IJavaScriptExecutor)Driver).ExecuteScript(
                        "return window.jQuery != undefined && jQuery.active == 0");
                //a variable JQuery uses internally to track the number of simultaneous AJAX requests
                //WaitForServiceTextVisible until the value of jQuery.active is zero, and continue the next operation.
                if (is_ajax_compete)
                {
                    return;
                }

                System.Threading.Thread.Sleep(1000);
            }

            throw new Exception("Timed out after " + maxSeconds + " seconds");
        }

        public void LogIn()
        {
            var privs = "";
            var username = Driver.FindElement(By.Id("Username"));
            var password = Driver.FindElement(By.Id("Password"));
            username.SendKeys(privs);
            password.SendKeys(privs);
            password.Submit();
        }
    }
}
