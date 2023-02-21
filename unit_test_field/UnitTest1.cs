using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace unit_test_field
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        
        public void FormTest()
        {
            By firstNameField = By.Name("First Name");
            By lastNameField = By.Name("Last Name");
            By mobileNumberField = By.Name("Mobile Number");
            By emailField = By.Name("Email");
            By resetButton = By.XPath("//button[@type='reset']");
            By maleRadioButton = By.Id("male");
            By femaleRadioButton = By.Id("female");
            By transgenderRadioButton = By.Id("transgender");


            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            IWebDriver webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            var firstNameFieldCheck = webDriver.FindElement(firstNameField);
            var lastNameFieldCheck = webDriver.FindElement(lastNameField);
            var mobileNumberFieldCheck = webDriver.FindElement(mobileNumberField);
            var emailFieldCheck = webDriver.FindElement(emailField);

            // First Name Field Test
            webDriver.FindElement(firstNameField).SendKeys("Ashin Sabu");
            Assert.IsTrue(firstNameFieldCheck.GetAttribute("value").Equals("Ashin Sabu"));
            Thread.Sleep(1000);

            // Reset Button Test
            webDriver.FindElement(resetButton).Click();
            Assert.IsTrue(
                firstNameFieldCheck.GetAttribute("value").Equals("") 
                && lastNameFieldCheck.GetAttribute("value").Equals("")
                && mobileNumberFieldCheck.GetAttribute("value").Equals("")
                && emailFieldCheck.GetAttribute("value").Equals("")
            );
            Thread.Sleep(1000);

            //Gender Radio Button Test
            var maleRadioButtonCheck = webDriver.FindElement(maleRadioButton);
            var femaleRadioButtonCheck = webDriver.FindElement(femaleRadioButton);
            var transgenderRadioButtonCheck = webDriver.FindElement(transgenderRadioButton);

            webDriver.FindElement(maleRadioButton).Click();
            Assert.IsTrue((femaleRadioButtonCheck.Selected == false && transgenderRadioButtonCheck.Selected == false));
            Thread.Sleep(1000);

            webDriver.FindElement(femaleRadioButton).Click();
            Assert.IsTrue((maleRadioButtonCheck.Selected == false && transgenderRadioButtonCheck.Selected == false));
            Thread.Sleep(1000);

            webDriver.FindElement(transgenderRadioButton).Click();
            Assert.IsTrue((femaleRadioButtonCheck.Selected == false && maleRadioButtonCheck.Selected == false));
            Thread.Sleep(1000);

            webDriver.Quit();

        }
    }
}
