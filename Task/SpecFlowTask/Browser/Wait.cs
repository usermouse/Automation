using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowTask.Browser
{
    public class Wait
    {
        private static IWebDriver _driver;
        public Wait(IWebDriver driver)
        {
            _driver = driver;
        }
        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)_driver;

            return javaScriptExecutor.ExecuteScript(javaScript);
        }

        public static void WaitReadyState()
        {
            Contract.Assume(_driver != null);
            int time = 0;
            var ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", _driver);

            while (!ready)
            {
                ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", _driver);

                if (time > 15000)
                    break;

                Thread.Sleep(100);
                time += 100;
            }
        }

        public static void WaitAjax()
        {

            Contract.Assume(_driver != null);
            int time = 0;
            var ready = (bool)ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;", _driver);

            while (!ready)
            {
                ready = (bool)ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;", _driver);

                if (time > 15000)
                    break;

                Thread.Sleep(100);
                time += 100;

            }
        }

        public static void UntilAnimationIsDone(string elementId, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            Until(_driver =>
            {
                var javaScriptExecutor = (IJavaScriptExecutor)_driver;
                var isAnimated = javaScriptExecutor
                    .ExecuteScript(string.Format("return $('#{0}').is(':animated')", elementId))
                    .ToString().ToLower();

                // return true when finished animating
                return !bool.Parse(isAnimated);
            }, timeoutInSeconds);
        }
        public static void Until(Func<IWebDriver, bool> waitCondition, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(waitCondition);
        }
    }
}
