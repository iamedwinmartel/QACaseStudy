using DemoQA.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class TextBox
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public TextBox(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement FullNameTextBox { get { return driver.FindElement(By.Id("userName")); } }
        public IWebElement EmailTextBox { get { return driver.FindElement(By.Id("userEmail")); } }
        public IWebElement CurrentAddressTextBox { get { return driver.FindElement(By.Id("currentAddress")); } }
        public IWebElement PermanentAddressTextBox { get { return driver.FindElement(By.Id("permanentAddress")); } }
        public IWebElement SubmitButton { get { return driver.FindElement(By.Id("submit")); } }
        public IWebElement OutputTextName { get { return driver.FindElement(By.XPath("//div[@id='output']//p[@id='name']")); } }
        public IWebElement OutputTextEmail { get { return driver.FindElement(By.XPath("//div[@id='output']//p[@id='email']")); } }
        public IWebElement OutputTextCurrentAddress { get { return driver.FindElement(By.XPath("//div[@id='output']//p[@id='currentAddress']")); } }
        public IWebElement OutputTextPermanentAddress { get { return driver.FindElement(By.XPath("//div[@id='output']//p[@id='permanentAddress']")); } }



    }
}
