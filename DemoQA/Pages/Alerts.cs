using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class Alerts
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public Alerts(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement AlertButton { get { return driver.FindElement(By.Id("alertButton")); } }
        public IWebElement TimerAlertButton { get { return driver.FindElement(By.Id("timerAlertButton")); } }
        public IWebElement ConfirmAlertButton { get { return driver.FindElement(By.Id("confirmButton")); } }
        public IWebElement PromptAlertButton { get { return driver.FindElement(By.Id("promtButton")); } }
        public IWebElement ConfirmResult { get { return driver.FindElement(By.Id("confirmResult")); } }
        public IWebElement PromptResult { get { return driver.FindElement(By.Id("promptResult")); } }



    }
}
