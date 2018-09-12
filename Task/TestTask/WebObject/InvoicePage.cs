using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowTask.Common;

namespace TestTask.WebObject
{
    public class InvoicePage : BasePage
    {
        private IWebDriver _driver;
        public InvoicePage()
        {
            _driver = base.driver;
        }

        public IWebElement HotelName(string name) => FindElement($"//table[contains(@class,'table-bordered')]//td[contains(text(),'{name}')]");
        public IWebElement TableElement => FindElement($"//table[contains(@class,'table-bordered')]");

        public IList<IWebElement> Table()
        {
            IList<IWebElement> tableRows = TableElement.FindElements(By.TagName("tr")).ToList();
            IList<IWebElement> rowTd = new List<IWebElement>();

            foreach (var row in tableRows)
            {
                rowTd = row.FindElements(By.TagName("td"));
            }

            return rowTd;
        }
    }
}
