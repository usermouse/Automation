

using System.Threading;
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
        private IWebDriver Driver;
        public MainPage()
        {
            Driver = WebDriver.Driver;
            WebDriver.WaitReadyState();
            WebDriver.WaitAjax();
        }

        public IWebElement MyAccaountButton => FindElement("//nav//li[@id='li_myaccount']/a");
        public IWebElement LoginButton => FindElement("//nav//li[@id='li_myaccount']//a[contains(@href,'/login')]");
        public IWebElement HotelName(string name) => FindElement($"//div[@id='bookings']//a/b[text()='{name}']");

        public void OpenLoginPage()
        {
            this.MyAccaountButton.Click();
            WebDriver.WaitReadyState();
            WebDriver.WaitAjax();
            this.LoginButton.Click();
            WebDriver.WaitReadyState();
            WebDriver.WaitAjax();
        }

        public void TryToFindAndScroll(string hotelName)
        {
            this.HotelName(hotelName).ScrollToElement(Driver);
        }

        [Given(@"Open phptravels site and login")]
        public void GivenOpenPhptravelsSiteAndLogin()
        {

            Driver.Navigate().GoToUrl(Settings.SiteUrl);

            new MainPage().OpenLoginPage();
            new LoginPage(Driver).Login();
        }

        [Then(@"Try to find hotel")]
        public void ThenTryToFindHotel(Table table)
        {
            WebDriver.WaitReadyState();
            WebDriver.WaitAjax();
            string hotelName = table.Rows[0]["Hotel"];
            var mainPage = new MainPage();
            mainPage.TryToFindAndScroll(hotelName);

            Assert.IsTrue(mainPage.HotelName(hotelName).Displayed, $"Hotel '{hotelName}' does not present on page");
        }

        [When(@"Open write review popup dialog")]
        public void WhenOpenWriteReviewPopupDialog(Table table)
        {
            var hotelName = table.Rows[0]["Hotel"];

            var accountPage = new AccountPage();
            accountPage.WriteReviewButton(hotelName).Click();
            WebDriver.WaitReadyState();
            WebDriver.WaitAjax();
        }

        [When(@"Configure parameters on review popup")]
        public void WhenConfigureParametersOnReviewPopup(Table table)
        {
            var cleanNummer = table.Rows[0]["clean"];
            var staffNummer = table.Rows[0]["staff"];

            var page = new WriteReviewPopup(Driver);

            
            page.CleanSelect.SelectOption(cleanNummer);
            page.StaffSelect.SelectOption(staffNummer);

        }

        [When(@"the write review message")]
        public void WhenTheWriteReviewMessage(Table table)
        {
            var page = new WriteReviewPopup(Driver);
            page.ReviewTextArea.SendKeys(table.Rows[0]["Message"]);
        }

        [When(@"Open invoice")]
        public void WhenOpenInvoice(Table table)
        {
            var hotelName = table.Rows[0]["Hotel"];

            var accountPage = new AccountPage();
            accountPage.InvoiceButton(hotelName).Click();
        }

        [Then(@"verify deposit information")]
        public void ThenVerifyDepositInformation(Table table)
        {
            SwitchToNewTab();
            var invoicePage = new InvoicePage();
            var a = invoicePage.Table();
        }
       
    }
}
