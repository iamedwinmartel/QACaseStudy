using DemoQA.Pages;
using DemoQA.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V115.Runtime;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class WebtableStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        Webtable webtable;
        PageUtils pageUtils;
        List<string> rowvalues;
        List<string> editedrowvalues;
        List<string> updatedrowvalues;

        public WebtableStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            webtable = new Webtable(scenarioContext);            
            pageUtils = new PageUtils(scenarioContext); 
        }

        [Then(@"Navigate to webtable section")]
        public void ThenNavigateToWebtableSection()
        {
            driver.Url = "https://demoqa.com/webtables";
        }

        [Then(@"Read the values in row (.*)")]
        public void ThenReadTheValuesInRow(int row)
        {
            rowvalues = webtable.GetRowValues(row);
        }

        [Then(@"Edit the values in row (.*)")]
        public void ThenEditTheValuesInRow(int row)
        {
            editedrowvalues = new List<string>();
            editedrowvalues.Add("a" + rowvalues[0]);
            editedrowvalues.Add("a" + rowvalues[1]);
            editedrowvalues.Add(rowvalues[2]);
            editedrowvalues.Add(rowvalues[3]);
            editedrowvalues.Add("1" + rowvalues[4]);
            editedrowvalues.Add("QA");

            webtable.ClickEditRow(row);

            pageUtils.EnterText(webtable.EditFirstName, editedrowvalues[0].ToString());
            pageUtils.EnterText(webtable.EditLastName, editedrowvalues[1].ToString());
            pageUtils.EnterText(webtable.EditEmail, editedrowvalues[3].ToString());            
            pageUtils.EnterText(webtable.EditAge, editedrowvalues[2].ToString());
            pageUtils.EnterText(webtable.EditSalary, editedrowvalues[4].ToString());
            pageUtils.EnterText(webtable.EditDepartment, editedrowvalues[5].ToString());
            webtable.EditSubmitButton.Click();
        }

        [Then(@"Verify if values were updated in row (.*)")]
        public void ThenVerifyIfValuesWereUpdatedInRow(int row)
        {            
            updatedrowvalues = webtable.GetRowValues(row);
            Assert.True(editedrowvalues.SequenceEqual(updatedrowvalues));
        }

    }
}
