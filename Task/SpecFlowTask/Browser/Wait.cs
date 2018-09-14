using System;
using System.Diagnostics.Contracts;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowTask.Browser
{
    public class Wait
    {
        private readonly IWebDriver _driver;
        public Wait(IWebDriver driver)
        {
            _driver = driver;
        }
        public object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)_driver;

            return javaScriptExecutor.ExecuteScript(javaScript);
        }

        public void WaitLoad()
        {
            UntilAnimationIsDone();
            WaitAjax();
            WaitReadyState();
        }

        public void WaitReadyState()
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

        public void WaitAjax()
        {

            Contract.Assume(_driver != null);
            int time = 0;
            while (time < 80)
            {
                bool ajaxFinished = (bool)((IJavaScriptExecutor)_driver).
                    ExecuteScript("return !!jQuery && jQuery.active == 0");

                if (ajaxFinished)
                    return;
                time++;
                Thread.Sleep(500);
            }
        }

        public void UntilAnimationIsDone(int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            Until(_driver =>
            {
                var javaScriptExecutor = (IJavaScriptExecutor)_driver;
                var isAnimated = javaScriptExecutor
                    .ExecuteScript("return $(':animated').length")
                    .ToString().ToLower().Equals("0");

                return isAnimated;
            }, timeoutInSeconds);
        }

        public void Until(Func<IWebDriver, bool> waitCondition, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(waitCondition);
        }
    }
}
