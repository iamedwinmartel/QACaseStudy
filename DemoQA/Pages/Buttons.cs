using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class Buttons
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public Buttons(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement DoubleclickElement { get { return driver.FindElement(By.Id("doubleClickBtn")); } }
        public IWebElement RightClickElement { get { return driver.FindElement(By.Id("rightClickBtn")); } }

        public IWebElement ClickElement { get { return driver.FindElement(By.XPath("//button[text()='Click Me']")); } }
        public IWebElement DoubleclickMessageElement { get { return driver.FindElement(By.XPath("//*[@id='doubleClickMessage' and text()='You have done a double click']")); } }
        public IWebElement RightClickMessageElement { get { return driver.FindElement(By.XPath("//*[@id='rightClickMessage' and text()='You have done a right click']")); } }

        public IWebElement ClickMessageElement { get { return driver.FindElement(By.XPath("//*[@id='dynamicClickMessage' and text()='You have done a dynamic click']")); } }

    }
}
