using DemoQA.Pages;
using DemoQA.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class AlertsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        Alerts alerts;
        PageUtils pageUils;
        public AlertsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            alerts = new Alerts(scenarioContext);
            pageUils = new PageUtils(scenarioContext);
        }

        [Then(@"Navigate to alerts section")]
        public void ThenNavigateToAlertsSection()
        {
            driver.Url = "https://demoqa.com/alerts";
            driver.Manage().Window.Maximize();
        }

        [Then(@"Click button for alert and click ok")]
        public void ThenClickButtonForAlertAndClickOk()
        {
           
            bool alert = pageUils.IsAlertPresent();
            alerts.AlertButton.Click();
            driver.SwitchTo().Alert().Accept();
            Assert.True(!pageUils.IsAlertPresent());
        }

        [Then(@"Click button for (.*) second delay alert and click ok")]
        public void ThenClickButtonForSecondDelayAlertAndClickOk(int p0)
        {
            alerts.TimerAlertButton.Click();

            int counter = 0;
            while (!pageUils.IsAlertPresent() || counter > 7)
            {
                System.Threading.Thread.Sleep(1000);
                counter++;
            }            
            
            driver.SwitchTo().Alert().Accept();
            Assert.True(!pageUils.IsAlertPresent());            
        }

        [Then(@"Click button for alert click ok and verify status")]
        public void ThenClickButtonForAlertClickOkAndVerifyStatus()
        {
            alerts.ConfirmAlertButton.Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Assert.True(alerts.ConfirmResult.Text == "You selected Ok");
        }

        [Then(@"Click button for alert click cancel and verify status")]
        public void ThenClickButtonForAlertClickCancelAndVerifyStatus()
        {
            alerts.ConfirmAlertButton.Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Alert().Dismiss();
            Assert.True(alerts.ConfirmResult.Text == "You selected Cancel");
        }

        [Then(@"Click button for alert and enter name in prompted alert")]
        public void ThenClickButtonForAlertAndEnterNameInPromptedAlert()
        {
            new Actions(driver).ScrollToElement(alerts.PromptAlertButton).Build().Perform();
            alerts.PromptAlertButton.Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Alert().SendKeys("test");
            driver.SwitchTo().Alert().Accept();
            Assert.True(alerts.PromptResult.Text == "You entered test");
        }
    }
}
