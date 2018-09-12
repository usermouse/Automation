using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowTask.Browser
{
    public class WebDriver
    {
        public static IWebDriver Driver { set; get; }

        public void InitialSettings()
        {
            new Settings().SettingManager();
        }

        //public IWebElement FindElement(string xPath)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(60));
        //        var element = wait.Until<IWebElement>(
        //            (d) => { return d.FindElement(By.XPath(xPath)); }
        //            );
        //    }
        //    catch { }

        //    return Driver.FindElement(By.XPath(xPath));
        //}

        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;

            return javaScriptExecutor.ExecuteScript(javaScript);//, args);
        }
        public static void WaitReadyState()
        {
            Contract.Assume(Driver != null);

            int time = 0;

            //var ready = new Func<bool>(() => (bool)ExecuteJavaScript("return document.readyState == 'complete'", driver));
            var ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", Driver);
            while (!ready)
            {
                ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", Driver);

                if (time > 15000)
                    break;

                Thread.Sleep(100);
                time += 100;
            }

            //Thread.Sleep(1000);
            //Console.WriteLine("ready1 = " + ready.Invoke());
        }

        public static void WaitAjax()
        {

            Contract.Assume(Driver != null);
            int time = 0;
            var ready = (bool)ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;", Driver);

            while (!ready)
            {
                ready = (bool)ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;", Driver);

                if (time > 15000)
                    break;

                Thread.Sleep(100);
                time += 100;

            }

            //Thread.Sleep(1000);
            //WaitForAjaxRequests();
            //Console.WriteLine("ready2 = " + ready);
        }
    }
}
