using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;


namespace SpecFlowTask.Browser
{
    public abstract class Browsers
    {
        public static IWebDriver Driver { set; get; }

        public void OpenBrowser()
        {
            string browserType = Settings.Browser;

            InitialBrowser(browserType);
        }

        public void InitialSettings()
        {
            new Settings().SettingManager();
        }

        private void InitialBrowser(string browserType = "chrome")
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    Driver = LaunchChromeBrowser(browserType);
                    break;
            }

            Driver.Manage().Window.Position = new Point(1, 1);
            Driver.Manage().Window.Maximize();
        }

        private IWebDriver LaunchChromeBrowser(string userAgentType)
        {
            var chromeOptions = GetChromeOptions(userAgentType);

            return new ChromeDriver($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Drivers\\Chrome", chromeOptions);
        }

        private ChromeOptions GetChromeOptions(string userAgentType)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--always-authorize-plugins");
            chromeOptions.AddArgument("--no-default-browser-check");
            chromeOptions.AddArgument("--disable-translate");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddArgument("--v=1");

            return chromeOptions;
        }
    }

}
