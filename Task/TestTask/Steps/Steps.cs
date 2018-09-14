using NUnit.Framework;
using SpecFlowTask;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;
using TestTask.WebObject;

namespace TestTask.Steps
{
    [Binding]
    public class Steps : BasePage
    {
        [Given(@"Open phptravels site and login")]
        public void GivenOpenPhptravelsSiteAndLogin()
        {
            driver.Navigate().GoToUrl(Settings.SiteUrl);

            new MainPage().OpenLoginPage();
            new LoginPage().Login();
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

            var page = new WriteReviewPopup();

            page.ReviewTextArea.IsDisplayed();
            page.CleanSelect.SelectOption(cleanNummer);
            page.StaffSelect.SelectOption(staffNummer);

        }
        [When(@"the write review message and close dialog")]
        public void WhenTheWriteReviewMessageAndCloseDialog(Table table)
        {
            var reviewMessage = table.Rows[0]["Message"];
            var page = new WriteReviewPopup();
            page.ReviewTextArea.SendKeys(reviewMessage);
            page.CloseButton.Click();
            page.SubmitButton.IsNotDisplayed();
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

            if(resultData.Count ==0)
                Assert.IsFalse(true, "Deposit information does not exist");

            foreach (var item in resultData)
            {
                Assert.IsTrue(table.Rows[0][item.Key] == item.Value, $"Deposit information are wrong - {item.Key}:{item.Value} and should be {item.Key}:{table.Rows[0][item.Key]}");
            }
        }
    }
}
