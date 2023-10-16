using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public InteractionsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement NewUserButton { get { return driver.FindElement(By.Id("newUser")); } }
        public IWebElement RegisterFirstName { get { return driver.FindElement(By.Id("firstname")); } }


        [Then(@"Navigate to sortable section")]
        public void ThenNavigateToSortableSection()
        {
            driver.Url = "https://demoqa.com/sortable";
        }

        [Then(@"Sort the blocks in descending order")]
        public void ThenSortTheBlocksInDescendingOrder()
        {
            driver.Manage().Window.Maximize();
            new Actions(driver)
                  .ScrollToElement(driver.FindElement(By.XPath("//span[text()='Resizable']")))
                  .Perform();

            IList <IWebElement> blocks = driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[@class='list-group-item list-group-item-action']"));
            List<string> blockTextBeforeSortList = blocks.Select(x=>x.Text).ToList<string>();
            for ( int i = 1; i<blocks.Count(); i++) 
            {
                System.Threading.Thread.Sleep(1000);
                

                new Actions(driver)                    
                    .ClickAndHold(blocks[0])
                    .MoveToElement(blocks[(blocks.Count())-i])
                    .Release()
                    .Release()
                    .Perform();
            }

            blocks = driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[@class='list-group-item list-group-item-action']"));
            List<string> blockTextAfterSortList = blocks.Select(x => x.Text).ToList<string>();
            blockTextAfterSortList.Reverse();

            Assert.True(blockTextBeforeSortList.SequenceEqual(blockTextAfterSortList));
        }

        [Then(@"Navigate to Droppable section")]
        public void ThenNavigateToDroppableSection()
        {
            driver.Url = "https://demoqa.com/droppable";
        }

        [Then(@"drag and drop a block")]
        public void ThenDragAndDropABlockToLastPosition()
        {
            IWebElement draggable = driver.FindElement(By.Id("draggable"));
            IWebElement droppable = driver.FindElement(By.Id("droppable"));

            new Actions(driver).DragAndDrop(draggable, droppable).Perform();
            Assert.True(droppable.FindElement(By.XPath("./p")).Text == "Dropped!");
        }
    }
}
