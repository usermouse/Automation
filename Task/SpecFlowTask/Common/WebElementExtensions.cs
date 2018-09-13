using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpecFlowTask.Common
{
    public static class WebElementExtensions
    {
        public static IWebElement MouseHover(this IWebElement webElement , IWebDriver webDriver)
        {
            Actions builder = new Actions(webDriver);
            builder.MoveToElement(webElement);
            builder.Build().Perform();
            return webElement;
        }

        public static IWebElement ScrollToElement(this IWebElement webElement, IWebDriver webDriver, int topMargin = 100, int bottomMargin = 100)
        {
            const string GetWindowInfoScript = "return { 'scroll' : window.pageYOffset, 'height' : window.innerHeight };";

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            var data = (Dictionary<string, object>)js.ExecuteScript(GetWindowInfoScript);
            var scrollPosition = double.Parse(data["scroll"].ToString());
            var browserInnerHeight = double.Parse(data["height"].ToString());

            
            var webElementPositionTop = webElement.Location.Y;
            var topMinPosition = scrollPosition + topMargin;

            if (webElementPositionTop <= topMinPosition)
            {
                var offsetY = topMinPosition - webElementPositionTop;
                js.ExecuteScript($"window.scrollBy(0,{-(int)offsetY})");
                return webElement;
            }

            var webElementPositionBottom = webElementPositionTop + webElement.Size.Height;
            var bottomMaxPosition = scrollPosition + browserInnerHeight - bottomMargin;

            if (webElementPositionBottom >= bottomMaxPosition)
            {
                var offsetY = webElementPositionBottom - bottomMaxPosition;
                js.ExecuteScript($"window.scrollBy(0,{(int)offsetY})");
                return webElement;
            }

            return webElement;
        }

        public static bool SelectOption(this IWebElement webElement, string text)
        {
            foreach (IWebElement option in webElement.GetOptions())
            {
                if (option.GetAttribute("value").Trim() == text)
                {
                    if (!option.Selected)
                    {
                        option.Click();
                    }

                    return true;
                }
            }

            return false;
        }

        public static IList<IWebElement> GetOptions(this IWebElement webElement)
        {
            return webElement.FindElements(By.TagName("option"));
        }

        public static IWebElement Click(this IWebElement webElement, IWebElement webDriver, string action = "mouse")
        {
            switch (action)
            {
                case "mouse":
                    webElement.Click();
                    break;
                case "script":
                    IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                    js.ExecuteScript("arguments[0].click();", webElement);
                    break;
            }

            return webElement;
        }

        public static void WaitForElementPresent(this IWebElement element)
        {
            int timeout = 0;

            while (timeout < 10000)
            {
                try
                {
                    if (element.IsDisplayed())
                    {
                        break;
                    }
                }
                catch { }

                Thread.Sleep(100);
                timeout += 200;
            }
        }

        public static bool IsDisplayed(this IWebElement webElement)
        {
            if (!webElement.Displayed)
            {
                return false;
            }

            try
            {
                var displayValue = webElement.GetCssValue("display");
                return !(displayValue.Contains("none") || webElement.Size.IsEmpty);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsNotDisplayed(this IWebElement webElement)
        {
            int count = 0;
            while (count <= 10)
            {
                if (!webElement.Displayed)
                    return true;

                count++;
                Thread.Sleep(100);
            }

            return false;
        }
    }
}
