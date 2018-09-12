using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTask.Browser;
using SpecFlowTask.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTask.WebObject;

namespace TestTask.Steps
{
    [Binding]
    public class WriteReviewSteps
    {
        //private IWebDriver Driver;
        //public WriteReviewSteps(WebDriver driver)
        //{
        //    Driver = driver.Driver;
        //}

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
