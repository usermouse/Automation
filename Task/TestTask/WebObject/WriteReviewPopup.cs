using OpenQA.Selenium;
using SpecFlowTask.Common;

namespace TestTask.WebObject
{
    public class WriteReviewPopup :BasePage
    {
        public IWebElement CleanSelect => FindElement($"//div[contains(@style,'display: block;')]//select[@name='reviews_clean']");
        public IWebElement ComfortSelect => FindElement($"//div[contains(@style,'display: block;')]//select[@name='reviews_comfort']");
        public IWebElement LocationSelect => FindElement($"//div[contains(@style,'display: block;')]//select[@name='reviews_location']");
        public IWebElement FacilitiesSelect => FindElement($"//div[contains(@style,'display: block;')]//select[@name='reviews_facilities']");
        public IWebElement StaffSelect => FindElement($"//div[contains(@style,'display: block;')]//select[@name='reviews_staff']");
        public IWebElement ReviewTextArea => FindElement($"//div[contains(@style,'display: block;')]//textarea[@name='reviews_comments']");
        public IWebElement CloseButton => FindElement($"//div[contains(@style,'display: block;')]//button[@type='button' and contains(@class, 'close')]");
        public IWebElement SubmitButton => FindElement($"//div[contains(@style,'display: block;')]//button[@type='button' and contains(@class, 'addreview')]");
    }
}
