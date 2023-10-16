using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class ButtonsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        Buttons buttons;

        public ButtonsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            buttons = new Buttons(scenarioContext);
        }

        [Then(@"Navigate to buttons section")]
        public void ThenNavigateToButtonsSection()
        {
            driver.Url = "https://demoqa.com/buttons";
        }

        [Then(@"on page perform a double click on relevant button and verify status")]
        public void WhenOnPagePerformADoubleClickOnRelevantButtonAndVerifyStatus()
        {
            new Actions(driver).DoubleClick(buttons.DoubleclickElement).Perform();
            Assert.True(buttons.DoubleclickMessageElement.Displayed);
        }

        [Then(@"perform a right click on relevant button and verify status")]
        public void WhenPerformARightClickOnRelevantButtonAndVerifyStatus()
        {
            new Actions(driver).ContextClick(buttons.RightClickElement).Perform();
            Assert.True(buttons.RightClickMessageElement.Displayed);
            new Actions(driver).SendKeys(Keys.Tab).Perform();
        }

        [Then(@"perform a click on relevant button and verify status")]
        public void WhenPerformAClickOnRelevantButtonAndVerifyStatus()
        {
            new Actions(driver).Click(buttons.ClickElement).Perform();
            Assert.True(buttons.ClickMessageElement.Displayed);
        }
    }
}
