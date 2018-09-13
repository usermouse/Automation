using OpenQA.Selenium;
using SpecFlowTask.Common;

namespace TestTask.WebObject
{
    public class WriteReviewPopup :BasePage
    {
        public IWebElement CleanSelect => FindElement($"//div[@style='display: block;']//select[@name='reviews_clean']");
        public IWebElement ComfortSelect => FindElement($"//div[@style='display: block;']//select[@name='reviews_comfort']");
        public IWebElement LocationSelect => FindElement($"//div[@style='display: block;']//select[@name='reviews_location']");
        public IWebElement FacilitiesSelect => FindElement($"//div[@style='display: block;']//select[@name='reviews_facilities']");
        public IWebElement StaffSelect => FindElement($"//div[@style='display: block;']//select[@name='reviews_staff']");
        public IWebElement ReviewTextArea => FindElement($"//div[@style='display: block;']//textarea[@name='reviews_comments']");
        public IWebElement CloseButton => FindElement($"//div[@style='display: block;']//button[@type='button' and contains(@class, 'close')]");
        public IWebElement SubmitButton => FindElement($"//div[@style='display: block;']//button[@type='button' and contains(@class, 'addreview')]");
    }
}
