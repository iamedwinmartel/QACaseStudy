using Bogus;
using DemoQA.Drivers;
using DemoQA.Pages;
using DemoQA.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        BrowserDriver browserDriver;
        Login login;
        Faker faker;
        PageUtils pageUtils;
        string username;
        string password;
        
        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
            login = new Login(scenarioContext);
            faker = new Faker();
            pageUtils = new PageUtils(scenarioContext);
        }

        [Then(@"Navigate to register section")]
        public void ThenNavigateToRegisterSection()
        {
            driver.Url = "https://demoqa.com/register";
            driver.Manage().Window.Maximize();
        }    

        [Then(@"Register User")]
        public void ThenRegisterUser()
        {
            login.RegisterFirstName.SendKeys("TestFirstName");
            login.RegisterLastName.SendKeys("TestLastName");

            username = faker.Internet.UserName(null) + "123";
            login.RegisterUserName.SendKeys(username);

            password = faker.Internet.Password() + "@1";
            login.RegisterPassword.SendKeys(password);

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", login.RegisterCaptcha);
            System.Threading.Thread.Sleep(2000);
            driver.SwitchTo().DefaultContent();

            //***** the captcha images pops up sporadically this impacts the execution 
            //pageUtils.ElementWaitUntilClickable(login.RegisterButton, 5);
            //System.Threading.Thread.Sleep(3000);
            //login.RegisterButton.Click();
            //System.Threading.Thread.Sleep(2000);


            //if (pageUtils.IsAlertPresent())
            //    driver.SwitchTo().Alert().Accept();
            //else
            //    Assert.Fail("User not registered");
        }



        [When(@"Login user after registration")]
        public void WhenLoginUserAfterRegistration()
        {
            driver.Url = "https://demoqa.com/login";
            login.LoginUserName.SendKeys("");
            login.LoginPassword.SendKeys("Password@1");
            System.Threading.Thread.Sleep(1000);
            new Actions(driver).SendKeys(Keys.Tab).Perform();
            pageUtils.ElementWaitUntilClickable(login.LoginButton, 10);
            login.LoginButton.Click();
        }

        [When(@"Verify user login")]
        public void WhenVerifyUserLogin()
        {
            System.Threading.Thread.Sleep(1000);
            pageUtils.ElementWaitUntilClickable(login.LogoutButton, 10);
            Assert.True(login.LogoutButton.Displayed, "User login successful");
        }
    }
}
