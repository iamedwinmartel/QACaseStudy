using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class FileUploadDownload
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public FileUploadDownload(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement FileUploadElement { get { return driver.FindElement(By.XPath("//input[@id='uploadFile' and @type='file']")); } }
        public IWebElement FileDownloadElement { get { return driver.FindElement(By.Id("downloadButton")); } }

        public IWebElement FileUploadedPathElement { get { return driver.FindElement(By.Id("uploadedFilePath")); } }
        


    }
}
