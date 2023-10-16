using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class TabsWIndowsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        TabsWindows tabsWindows;
        public TabsWIndowsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            tabsWindows = new TabsWindows(scenarioContext);
        }

        [Then(@"Navigate to browser windows section")]
        public void ThenNavigateToBrowserWindowsSection()
        {
            driver.Url = "https://demoqa.com/browser-windows";
        }

        [Then(@"click on new tab and switch")]
        public void ThenClickOnNewTabAndSwitch()
        {
            tabsWindows.NewTabElement.Click();

            var windowHandles = driver.WindowHandles;
            var window = driver.SwitchTo().Window(windowHandles[1]);
            window.Close();
            driver.SwitchTo().Window(windowHandles[0]);
        }

        [Then(@"click on new window and switch")]
        public void ThenClickOnNewWindowAndSwitch()
        {
            tabsWindows.NewWindowElement.Click();
                        
            var window = driver.SwitchTo().Window(driver.WindowHandles.Last());
            window.Close();
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [Then(@"click on new window and print message")]
        public void ThenClickOnNewWindowAndPrintMessage()
        {           
            tabsWindows.NewWindowMessageElement.Click();

            //Having issues in switching to this window
            //var windowHandles = driver.WindowHandles;
            //var window = driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Manage().Window.Maximize();
            //string bodyText = driver.FindElement(By.TagName("body")).Text;
            //Console.WriteLine(bodyText);           
        }
    }
}
