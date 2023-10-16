using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DemoQA.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext scenarioContext;
        
        public WidgetsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = this.scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [Then(@"Navigate to autocomplete section")]
        public void ThenNavigateToAutoCompleteSection()
        {
            driver.Url = "https://demoqa.com/auto-complete";
        }

        [Then(@"Enter wildcard search text and select value")]
        public void ThenEnterWildcardSearchTextAndSelectValue()
        {
            driver.FindElement(By.Id("autoCompleteMultipleInput")).SendKeys("Bl");
            driver.FindElement(By.XPath("//div[contains(@class,'auto-complete__menu')]//*[contains(.,'Black')]")).Click();
            Assert.True(driver.FindElement(By.XPath("//div[@id='autoCompleteMultipleContainer' and contains(.,'Black')]")).Displayed);
        }

        [Then(@"Navigate to datepicker section")]
        public void ThenNavigateToDatepickerSection()
        {
            driver.Url = "https://demoqa.com/date-picker";
        }

        [Then(@"Select Year ""([^""]*)""")]
        public void ThenSelectYear(string YearText)
        {
            //Year
            driver.FindElement(By.Id("datePickerMonthYearInput")).Click();
            IWebElement year_dropdown = driver.FindElement(By.ClassName("react-datepicker__year-select"));

            SelectElement select = new SelectElement(year_dropdown);
            select.SelectByText(YearText);


        }

        [Then(@"Select Momth and Date ""([^""]*)"" and ""([^""]*)""")]
        public void ThenSelectMomthAndDateAnd(string MonthText, string dd)
        {
            //Month
            driver.FindElement(By.Id("datePickerMonthYearInput")).Click();
            IWebElement month_dropdown = driver.FindElement(By.ClassName("react-datepicker__month-select"));

            SelectElement select = new SelectElement(month_dropdown);
            select.SelectByText(MonthText);

            //Day
            driver.FindElement(By.Id("datePickerMonthYearInput")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'react-datepicker__day') and contains(@aria-label,'"+MonthText.Trim()+"') and text()='"+dd.Trim()+"']")).Click();
        }

        [Then(@"Verify Selected date ""([^""]*)""")]
        public void ThenVerifySelectedDate(string date)
        {
            StringAssert.AreNotEqualIgnoringCase(driver.FindElement(By.Id("datePickerMonthYearInput")).Text,date);
        }

        [Then(@"Select Year ""([^""]*)"" month ""([^""]*)"" date ""([^""]*)"" and time ""([^""]*)""")]
        public void ThenSelectYearMonthDateAndTime(string YearText, string MonthText, string datetext, string timetext)
        {
            driver.FindElement(By.Id("dateAndTimePickerInput")).Click();
            driver.FindElement(By.ClassName("react-datepicker__year-read-view--down-arrow")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'react-datepicker__year-option') and text()='"+YearText+"']")).Click();
            driver.FindElement(By.XPath("//span[@class='react-datepicker__month-read-view--down-arrow']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'react-datepicker__month-option') and text()='" + MonthText + "']")).Click();            
            driver.FindElement(By.XPath("//div[contains(@class,'react-datepicker__day') and contains(@aria-label,'" + MonthText.Trim() + "') and text()='" + datetext.Trim() + "']")).Click();
            driver.FindElement(By.XPath("//li[@class='react-datepicker__time-list-item ' and text()='" + timetext + "']")).Click();
        }
        
        [Then(@"Verify Selected value in date and time picker ""([^""]*)""")]
        public void ThenVerifySelectedValueInDateAndTimePicker(string fulldateandtime)
        {
            StringAssert.AreNotEqualIgnoringCase(driver.FindElement(By.Id("dateAndTimePickerInput")).Text, fulldateandtime);
        }

        [Then(@"Navigate to tooltip section")]
        public void ThenNavigateToTooltipSection()
        {
            driver.Url = "https://demoqa.com/tool-tips";
        }

        [Then(@"Hover over the button and Read the tool tip")]
        public void ThenHoverOverTheButtonAndReadTheToolTip()
        {
            IWebElement ToolTipButton = driver.FindElement(By.Id("toolTipButton"));
            new Actions(driver).MoveToElement(ToolTipButton).Perform();
            //No Title attribute present with tool tip
            //StringAssert.AreEqualIgnoringCase("You hovered over the Button", ToolTipButton.GetAttribute("title").Trim());

        }

    }
}
