using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowTask.Browser;
using SpecFlowTask.Common;

namespace TestTask.WebObject
{
    public class InvoicePage : BasePage
    {
        public IWebElement HotelName(string name) => FindElement($"//table[contains(@class,'table-bordered')]//td[contains(text(),'{name}')]");
        public IWebElement TableElement => FindElement($"//table[contains(@class,'table-bordered')]");

        public Dictionary<string, string> Table()
        {
            var tableTitleRows = TableElement.FindElements(By.XPath("//table[contains(@class,'table-bordered')]//thead//td")).Select(x=>x.Text).ToList();
            var tableDataRows = TableElement.FindElements(By.XPath("//table[contains(@class,'table-bordered')]//tbody//td")).Select(x=>x.Text).ToList();
            

            var tableData = new Dictionary<string, string>();

            for (int i = 0; i < tableTitleRows.Count(); i++)
            {
                if(!tableData.ContainsKey(tableTitleRows[i]))
                    tableData.Add(tableTitleRows[i], tableDataRows[i]);
            }

            return tableData;
        }
    }
}
