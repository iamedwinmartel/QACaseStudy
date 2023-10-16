using DemoQA.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Reflection;
using TechTalk.SpecFlow;

[assembly: LevelOfParallelism(2)]
[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace DemoQA.StepDefinitions
{
    [Binding]
    public class SetupBrowserStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        BrowserDriver browserDriver;
        public SetupBrowserStepDefinitions(ScenarioContext scenarioContext) 
        {
            this.scenarioContext = scenarioContext;
            browserDriver = new BrowserDriver(this.scenarioContext);
        }

        [Given(@"Setup browser (.*)")]
        public void GivenSetupBrowser(string browser)
        {
            
            driver = browserDriver.Setup(browser);
        }

        [Then(@"Launch DemoQA webpage")]
        public void ThenLaunchDemoQAWebpage()
        {
            //string Env = ConfigurationManager.AppSettings["Environment"].ToUpper();

            //if (Env == "QA")
            //    driver.Url = ConfigurationManager.AppSettings["QAUrl"].ToString();
            //else if (Env == "PREPROD")
            //    driver.Url = ConfigurationManager.AppSettings["PreProdUrl"].ToString();
            //else if (Env == "PROD")
            //    driver.Url = ConfigurationManager.AppSettings["ProdUrl"].ToString();

            driver.Url = "https://demoqa.com/";
        }

        [Then(@"Quit Browser")]
        public void ThenQuitBrowser()
        {
            browserDriver.Quit();
        }

    }
}
