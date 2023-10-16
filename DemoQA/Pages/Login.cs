using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Pages
{
    public class Login
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        public Login(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        //Locators
        public IWebElement NewUserButton { get { return driver.FindElement(By.Id("newUser")); } }
        public IWebElement RegisterFirstName { get { return driver.FindElement(By.Id("firstname")); } }
        public IWebElement RegisterLastName { get { return driver.FindElement(By.Id("lastname")); } }
        public IWebElement RegisterUserName { get { return driver.FindElement(By.Id("userName")); } }
        public IWebElement RegisterPassword { get { return driver.FindElement(By.Id("password")); } }
        public IWebElement RegisterCaptcha { get { return driver.FindElement(By.Id("recaptcha-anchor")); } }
        public IWebElement RegisterButton { get { return driver.FindElement(By.Id("register")); } }
        public IWebElement LoginUserName { get { return driver.FindElement(By.Id("userName")); } }
        public IWebElement LoginPassword { get { return driver.FindElement(By.Id("password")); } }
        public IWebElement LoginButton { get { return driver.FindElement(By.Id("login")); } }
        public IWebElement LogoutButton { get { return driver.FindElement(By.XPath("//button[@id='submit' and text()='Log out']")); } }
        

    }
}
