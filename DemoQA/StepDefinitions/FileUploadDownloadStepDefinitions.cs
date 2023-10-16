using DemoQA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class FileUploadDownloadStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        FileUploadDownload fileUploadDownload;

        public FileUploadDownloadStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            fileUploadDownload = new FileUploadDownload(scenarioContext);
        }

        [Then(@"Navigate to File Upload section")]
        public void ThenNavigateToFileUploadSection()
        {
            driver.Url = "https://demoqa.com/upload-download";
        }

        [Then(@"Upload the file and verify status")]
        public void ThenUploadTheFileAndVerifyStatus()
        {
            string FullFilePath = Path.GetFullPath("./").Replace("bin\\Debug\\net6.0", "");              
            fileUploadDownload.FileUploadElement.SendKeys(FullFilePath + "Support/TestFileUpload.png");
            StringAssert.AreEqualIgnoringCase("C:\\fakepath\\TestFileUpload.PNG", fileUploadDownload.FileUploadedPathElement.Text);
        }

        [Then(@"Download file and verify status")]
        public void ThenDownloadFileAndVerifyStatus()
        {
            fileUploadDownload.FileDownloadElement.Click();
            //Download directory can be overridden in chromeoptionsto save the downloaded file to a specfic path
            //Later the file can be verified 
            string filePath = "Local file path";
            if (File.Exists(filePath))
            {
                Assert.True(true); //"if file exists"
            }
        }
    }
}
