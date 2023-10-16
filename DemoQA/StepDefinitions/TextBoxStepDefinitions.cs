using DemoQA.Pages;
using DemoQA.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        TextBox textBox;
        PageUtils pageUtils;

        public TextBoxStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            textBox = new TextBox(this.scenarioContext);
            pageUtils = new PageUtils(this.scenarioContext);
        }

        [Then(@"Navigate to textbox section")]
        public void ThenNavigateToTextboxSection()
        {
            driver.Url = "https://demoqa.com/text-box";
        }

        [Then(@"Enter Fullname (.*)")]
        public void ThenEnterFullname(string FullName)
        {
            textBox.FullNameTextBox.SendKeys(FullName);      }

        [Then(@"Enter Email (.*)")]
        public void ThenEnterEmail(string emailaddress)
        {
            textBox.EmailTextBox.SendKeys(emailaddress);
        }

        [Then(@"Enter Current Address (.*)")]
        public void ThenEnterCurrentAddress(string currentAddress)
        {
            textBox.CurrentAddressTextBox.SendKeys(currentAddress);
        }

        [Then(@"Enter Permanent Address (.*)")]
        public void ThenEnterPermanentAddressPermanentStreetIndia(string permanentAddress)
        {
            textBox.PermanentAddressTextBox.SendKeys(permanentAddress);
        }
        
        [Then(@"Click Submit button")]
        public void ThenClickSubmitButton()
        {
            new Actions(driver).SendKeys(Keys.Tab).MoveToElement(textBox.SubmitButton).Build().Perform();
            pageUtils.ElementWaitUntilClickable(textBox.SubmitButton, 10);            
            textBox.SubmitButton.Click();
        }

        [Then(@"Verify Fullname after submission (.*)")]
        public void ThenVerifyFullnameAfterSubmissionEdwinMartel(string Fullname)
        {
            StringAssert.EndsWith(Fullname, textBox.OutputTextName.Text);
        }

        [Then(@"Verify Email after submission (.*)")]
        public void ThenVerifyEmailAfterSubmissionTestTest_Com(string email)
        {
            StringAssert.EndsWith(email, textBox.OutputTextEmail.Text);
        }

        [Then(@"Verify Current Address after submission (.*)")]
        public void ThenVerifyCurrentAddressAfterSubmissionCurrentStreetIndia(string currentAddress)
        {
            StringAssert.EndsWith(currentAddress, textBox.OutputTextCurrentAddress.Text);
        }

        [Then(@"Verify Permanent Address after submission (.*)")]
        public void ThenVerifyPermanentAddressAfterSubmissionPermanentStreetIndia(string permanentAddress)
        {
            StringAssert.EndsWith(permanentAddress, textBox.OutputTextPermanentAddress.Text);
        }
    }
}
