using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTask;
using SpecFlowTask.Browser;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;

namespace TestTask.WebObject
{
    [Binding]
    public class MainPage : BasePage
    {

        public IWebElement MyAccaountButton => FindElement("//nav//li[@id='li_myaccount']/a");
        public IWebElement LoginButton => FindElement("//nav//li[@id='li_myaccount']//a[contains(@href,'/login')]");
        public IWebElement HotelName(string name) => FindElement($"//div[@id='bookings']//a/b[text()='{name}']");

        public void OpenLoginPage()
        {
            this.MyAccaountButton.Click();
            this.LoginButton.Click();
        }

        public void TryToFindAndScroll(string hotelName)
        {
            this.HotelName(hotelName).ScrollToElement(driver);
        }
       
    }
}
