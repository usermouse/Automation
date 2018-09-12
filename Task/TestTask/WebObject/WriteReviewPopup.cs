using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTask.Browser;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;

namespace TestTask.WebObject
{
    public class WriteReviewPopup : BasePage
    {
        private IWebDriver Driver;
        public WriteReviewPopup(IWebDriver driver)
        {
            Driver = base.driver;
        }


        public IWebElement CleanSelect => FindElement($"//form[@id='reviews-form-7']//select[@name='reviews_clean']");
        public IWebElement ComfortSelect => FindElement($"//form[@id='reviews-form-7']//select[@name='reviews_comfort']");
        public IWebElement LocationSelect => FindElement($"//form[@id='reviews-form-7']//select[@name='reviews_location']");
        public IWebElement FacilitiesSelect => FindElement($"//form[@id='reviews-form-7']//select[@name='reviews_facilities']");
        public IWebElement StaffSelect => FindElement($"//form[@id='reviews-form-7']//select[@name='reviews_staff']");
        public IWebElement ReviewTextArea => FindElement($"//div[@id='AddReview7']//button[@type='button' and contains(@class, 'addreview') ]");

        //[When(@"Configure parameters on review popup")]
        //public void WhenConfigureParametersOnReviewPopup(Table table)
        //{
        //    var cleanNummer = table.Rows[0]["clean"];
        //    var staffNummer = table.Rows[0]["staff"];

        //    var page = new WriteReviewPopup(Driver);

        //    page.CleanSelect.SelectOption(cleanNummer);
        //    page.StaffSelect.SelectOption(staffNummer);

        //    Assert.IsTrue(true);
        //}

    }
}
