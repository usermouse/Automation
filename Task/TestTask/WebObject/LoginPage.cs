using OpenQA.Selenium;
using SpecFlowTask;
using SpecFlowTask.Common;

namespace TestTask.WebObject
{
    public class LoginPage : BasePage
    {
        public IWebElement LoginInput => FindElement("//form[@id='loginfrm']//input[@type='email']");
        public IWebElement PasswordInput => FindElement("//form[@id='loginfrm']//input[@type='password']");
        public IWebElement LoginButton => FindElement("//form[@id='loginfrm']//button[contains(@class,'loginbtn')]");
        public IWebElement RememberMeButtoin => FindElement("//form[@id='loginfrm']//input[@id='remember-me']");

        public void Login()
        {
            LoginInput.SendKeys(Settings.Login);
            PasswordInput.SendKeys(Settings.Passwd);
            LoginButton.Click();
        }

    }
}
