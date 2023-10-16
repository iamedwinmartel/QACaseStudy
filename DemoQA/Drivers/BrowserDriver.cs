using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Drivers
{
   public class BrowserDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public BrowserDriver(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
        public IWebDriver Setup(string browser)
        {
            driver = InitializeWebDriver(browser);
            this.scenarioContext.Set(driver, "WebDriver");
            return driver;
        }        

        private IWebDriver InitializeWebDriver(string browser)
        {
            switch (browser.ToUpper())
            {
                case "CHROME":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "EDGE":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:                    
                    throw new NotSupportedException("Invalid browser");
            }

            return driver;
        }

        public void Quit()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}

