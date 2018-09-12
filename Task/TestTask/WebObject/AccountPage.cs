

using OpenQA.Selenium;
using SpecFlowTask.Browser;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;

namespace TestTask.WebObject
{
    public class AccountPage : BasePage
    {
        private IWebDriver _driver;
        public AccountPage()
        {
            _driver = base.driver;
        }

        public IWebElement HotelName(string name) => FindElement($"//div[@id='bookings']//a/b[text()='{name}']");
        public IWebElement InvoiceButton(string name) => FindElement($"//div[@id='bookings']//div[@class='row' and .//b[text()='{name}']]//a[contains(@href,'invoice?') and @target='_blank']");
        public IWebElement WriteReviewButton(string name) => FindElement($"//div[@id='bookings']//div[@class='row' and .//b[text()='{name}']]//span[contains(@class,'write_review')]");

        //[When(@"Open write review popup dialog")]
        //public void WhenOpenWriteReviewPopupDialog(Table table)
        //{
        //    var hotelName = table.Rows[0]["Hotel"];

        //    var accountPage = new AccountPage();
        //    accountPage.WriteReviewButton(hotelName).Click();
        //}
    }
}
