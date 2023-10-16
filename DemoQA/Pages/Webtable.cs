using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V115.Fetch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{    public class Webtable
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public Webtable(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement Table { get { return driver.FindElement(By.ClassName("rt-table")); } }
        public IWebElement Body { get { return driver.FindElement(By.ClassName("rt-body")); } }

        public IWebElement EditFirstName { get { return driver.FindElement(By.Id("firstName")); }}
        public IWebElement EditLastName { get { return driver.FindElement(By.Id("lastName")); } }
        public IWebElement EditEmail { get { return driver.FindElement(By.Id("userEmail")); } }
        public IWebElement EditAge { get { return driver.FindElement(By.Id("age")); } }
        public IWebElement EditSalary { get { return driver.FindElement(By.Id("salary")); } }
        public IWebElement EditDepartment { get { return driver.FindElement(By.Id("department")); } }
        public IWebElement EditSubmitButton { get { return driver.FindElement(By.Id("submit")); } }
        public List<string> GetRowValues(int rownumber)
        {                         
            IList<IWebElement> rows = driver.FindElements(By.XPath("//div[@class='rt-tbody']//div[@role='row']"));
            IList<IWebElement> cells = rows.ElementAt(rownumber - 1).FindElements(By.XPath(".//div[@role='gridcell' and not(child::*)]"));
            List<string> rowvalues = new List<string>();
            rowvalues = cells.Select(v => v.Text.Trim()).ToList();

            return rowvalues;
        }

        public void ClickEditRow(int rownumber)
        {
            IList<IWebElement> rows = driver.FindElements(By.XPath("//div[@class='rt-tbody']//div[@role='row']"));
            IWebElement editcellicon = rows.ElementAt(rownumber - 1).FindElement(By.XPath(".//div[@role='gridcell']//span[contains(@id,'edit-record')]"));
            editcellicon.Click();
        }
    }
}
