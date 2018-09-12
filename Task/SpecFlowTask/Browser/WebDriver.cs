using System.Diagnostics.Contracts;
using System.Threading;
using OpenQA.Selenium;

namespace SpecFlowTask.Browser
{
    public class WebDriver
    {
        public static IWebDriver Driver { set; get; }

        public void InitialSettings()
        {
            new Settings().SettingManager();
        }

        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;

            return javaScriptExecutor.ExecuteScript(javaScript);//, args);
        }

        public static void WaitReadyState()
        {
            Contract.Assume(Driver != null);
            int time = 0;
            var ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", Driver);

            while (!ready)
            {
                ready = (bool)ExecuteJavaScript("return document.readyState == 'complete'", Driver);

                if (time > 15000)
                    break;

                Thread.Sleep(100);
                time += 100;
            }
        }

        public static void WaitAjax()
        {

            Contract.Assume(Driver != null);
            int time = 0;
            while (time < 80)
            {
                bool ajaxFinished = (bool)((IJavaScriptExecutor)Driver).
                    ExecuteScript("return !!jQuery && jQuery.active == 0");

                if (ajaxFinished)
                    return;
                time++;
                Thread.Sleep(500);
            }
        }
    }
}
