using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTask;
using SpecFlowTask.Browser;
using TechTalk.SpecFlow;
using TestTask.WebObject;

namespace TestTask.Steps
{
    [Binding]
    public class MainSteps : Browsers
    {

        [BeforeScenario]
        public void BefereScenario()
        {
            InitialSettings();
            OpenBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {

        }

       //[Given(@"Open phptravels site and login")]
       // public void GivenOpenPhptravelsSiteAndLogin()
       // {

       //     Driver.Navigate().GoToUrl(Settings.SiteUrl);

       //     new MainPage(Driver).OpenLoginPage();
       //     new LoginPage(Driver).Login();
       // }

       // [Then(@"Try to find hotel")]
       // public void ThenTryToFindHotel(Table table)
       // {
       //     string hotelName = table.Rows[0]["Hotel"];
       //     var mainPage = new MainPage(Driver);
       //     mainPage.TryToFindAndScroll(hotelName);

       //     Assert.IsTrue(mainPage.HotelName(hotelName).Displayed, $"Hotel '{hotelName}' does not present on page");
       // }
    }
}
