using DemoQA.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Support
{
    public class PageUtils
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        TextBox textBox;

        public PageUtils(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            textBox = new TextBox(this.scenarioContext);
        }
        public void ElementWaitUntilClickable(IWebElement element,int seconds)
        { 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.Click();
            element.SendKeys(text);
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
    }
}
