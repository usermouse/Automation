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
        private readonly IWebDriver _driver;
        public MainPage()
        {
            _driver = WebDriver.Driver;
        }

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
            this.HotelName(hotelName).ScrollToElement(_driver);
        }

        [Given(@"Open phptravels site and login")]
        public void GivenOpenPhptravelsSiteAndLogin()
        {

            _driver.Navigate().GoToUrl(Settings.SiteUrl);

            new MainPage().OpenLoginPage();
            new LoginPage(_driver).Login();
        }

        [Then(@"Try to find hotel")]
        public void ThenTryToFindHotel(Table table)
        {
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
        }

        [When(@"Configure parameters on review popup")]
        public void WhenConfigureParametersOnReviewPopup(Table table)
        {
            var cleanNummer = table.Rows[0]["clean"];
            var staffNummer = table.Rows[0]["staff"];

            var page = new WriteReviewPopup(_driver);

            
            page.CleanSelect.SelectOption(cleanNummer);
            page.StaffSelect.SelectOption(staffNummer);

        }
        [When(@"the write review message and close dialog")]
        public void WhenTheWriteReviewMessageAndCloseDialog(Table table)
        {
            var reviewMessage = table.Rows[0]["Message"];
            var page = new WriteReviewPopup(_driver);
            page.ReviewTextArea.SendKeys(reviewMessage);
            page.CloseButton.Click();
        }

        [When(@"Open invoice from '(.*)' hotel")]
        public void WhenOpenInvoiceFromHotel(string hotelName)
        {
            var accountPage = new AccountPage();
            accountPage.InvoiceButton(hotelName).Click();
        }

        [Then(@"verify deposit information")]
        public void ThenVerifyDepositInformation(Table table)
        {
            SwitchToNewTab();
            var invoicePage = new InvoicePage();
            var resultData = invoicePage.Table();

            foreach (var item in resultData)
            {
                Assert.IsTrue(table.Rows[0][item.Key] == item.Value);
            }
        }
       
    }
}
