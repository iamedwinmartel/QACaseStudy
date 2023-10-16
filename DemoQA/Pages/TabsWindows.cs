using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class TabsWindows
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public TabsWindows(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement NewTabElement { get { return driver.FindElement(By.Id("tabButton")); } }
        public IWebElement NewWindowElement { get { return driver.FindElement(By.Id("windowButton")); } }
        public IWebElement NewWindowMessageElement { get { return driver.FindElement(By.Id("messageWindowButton")); } }
        

    }
}
