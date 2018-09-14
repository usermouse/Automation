using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowTask.Browser;

namespace SpecFlowTask.Common
{
    public class BasePage : Browsers
    {
        public IWebDriver driver;

        public BasePage()
        {
            driver = Driver;
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(69);
        }

        public IWebElement FindElement(string xPath)
        {
            new Wait(driver).WaitLoad();
            
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
                wait.Until(d => ExpectedConditions.ElementExists(By.XPath(xPath)));
            }
            catch (Exception e)
            {
                return null;
            }

            return driver.FindElement(By.XPath(xPath));
        }

        public void SwitchToNewTab()
        {

            int counter = 30;
            int count = driver.WindowHandles.Count;
            while (counter-- > 0)
            {
                Thread.Sleep(100);
            }

            Assert.That(driver.WindowHandles.Count, Is.GreaterThanOrEqualTo(2), "There should be at least two tabs opened");
            var winHandles = driver.WindowHandles;

            driver.SwitchTo().Window(winHandles[winHandles.Count - 1]);
            Thread.Sleep(1000);

        }
    }
}
