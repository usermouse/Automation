using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowTask.Browser;

namespace SpecFlowTask.Common
{
    public class BasePage
    {
        public IWebDriver driver =  WebDriver.Driver;
        public IWebElement FindElement(string xPath)
        {
            new Wait(driver).WaitAjax();
            new Wait(driver).WaitReadyState();

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(
                    (d) =>
                    {
                        return d.FindElement(By.XPath(xPath));
                    }
                    );
            }
            catch { }

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
