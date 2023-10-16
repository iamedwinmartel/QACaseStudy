using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class CheckBoxStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public CheckBoxStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [Then(@"Navigate to checkbox section")]
        public void ThenNavigateToCheckboxSection()
        {
            driver.Url = "https://demoqa.com/checkbox";
        }

        [Then(@"Select check box ""([^""]*)""")]
        public void ThenSelectCheckBox(string item)
        {
            driver.FindElement(By.XPath("//span[@class='rct-checkbox' and following-sibling::span[text()='" + item.ToString() + "']]")).Click();
            string ClassnameAfterSelection = driver.FindElement(By.XPath("//span[@class='rct-checkbox' and following-sibling::span[text()='" + item.ToString() + "']]/*[contains(@class,'rct-icon')]")).GetAttribute("class");
            Assert.IsTrue(ClassnameAfterSelection.Equals("rct-icon rct-icon-check"), "Checkbox : " + item.ToString() + " selected.");
        }


        [Then(@"Expand all checkboxes")]
        public void ThenExpandAllCheckboxes()
        {
            driver.FindElement(By.XPath("//div[@class='rct-options']/button[@title='Expand all']")).Click();
        }


        [Then(@"Print which items are half checked")]
        public void ThenPrintWhichItemsAreHalfChecked()
        {
            ;
            IList<IWebElement> HalfCheckedItems = driver.FindElements(By.XPath("//span[@class='rct-checkbox' and child::*[contains(@class,'rct-icon-half-check')]]/following-sibling::span[@class='rct-title']"));
            foreach (var Item in HalfCheckedItems)
            {
                Console.WriteLine(Item.Text);
            }
        }

        [Then(@"Print which items remain unchecked")]
        public void ThenPrintWhichItemsRemainUnchecked()
        {
            IList<IWebElement> UnCheckedItems = driver.FindElements(By.XPath("//span[@class='rct-checkbox' and child::*[contains(@class,'rct-icon-uncheck')]]/following-sibling::span[@class='rct-title']"));
            foreach (var Item in UnCheckedItems)
            {
                Console.WriteLine(Item.Text);
            }
        }

        [Then(@"Unselect already selected items")]
        public void ThenUnselectAlreadySelectedItems()
        {           
            IList<IWebElement> CheckedItems = driver.FindElements(By.XPath("//span[@class='rct-checkbox' and child::*[contains(@class,'rct-icon-check')]]/following-sibling::span[@class='rct-title']"));
            foreach (var Item in CheckedItems)
            {
                Item.Click();
                Console.WriteLine(Item.Text);
            }
        }
    }
}