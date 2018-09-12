using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                var element = wait.Until<IWebElement>(
                    (d) => { return d.FindElement(By.XPath(xPath)); }
                    );
            }
            catch { }

            return driver.FindElement(By.XPath(xPath));
        }
    }
}
