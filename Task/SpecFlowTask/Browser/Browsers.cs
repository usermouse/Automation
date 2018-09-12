using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace SpecFlowTask.Browser
{
    public class Browsers : WebDriver
    {
        
        public void OpenBrowser()
        {
            string browserType = Settings.Browser;
            if (string.IsNullOrEmpty(browserType))
                InitialBrowser();
            else
                InitialBrowser(browserType);
        }

        private void InitialBrowser(string browserType = "chrome")
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    Driver = LaunchChromeBrowser(browserType);
                    break;

                case "ff":
                    Driver = this.LaunchFfBrowser(browserType);
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

        private IWebDriver LaunchFfBrowser(string userAgentType)
        {
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true,
                PageLoadStrategy = PageLoadStrategy.Eager,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
            };


            var service = FirefoxDriverService.CreateDefaultService(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Drivers\\Geco",
                "wires.exe");
            service.FirefoxBinaryPath = @"C:\\Program Files\\Mozilla Firefox\\firefox.exe";

            IWebDriver driver = new FirefoxDriver(service);
            return driver;
        }
    }

}
