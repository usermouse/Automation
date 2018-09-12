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

        
    }
}
