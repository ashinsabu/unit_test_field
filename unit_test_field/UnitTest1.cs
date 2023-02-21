using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
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
            By fileUploadField = By.XPath("//input[@type='file']");

            var chromeOptions = new ChromeOptions();

            // UNCOMMENT FOLLOWING LINE IF YOU WISH TO RUN TESTS IN HEADLESS MODE

            //chromeOptions.AddArguments("headless");

            

            IWebDriver webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            IJavaScriptExecutor jse = (IJavaScriptExecutor)webDriver;

            var firstNameFieldCheck = webDriver.FindElement(firstNameField);
            var lastNameFieldCheck = webDriver.FindElement(lastNameField);
            var mobileNumberFieldCheck = webDriver.FindElement(mobileNumberField);
            var emailFieldCheck = webDriver.FindElement(emailField);

            // Field 1 Test: First Name Field Test
            webDriver.FindElement(firstNameField).SendKeys("Ashin Sabu");
            Assert.IsTrue(firstNameFieldCheck.GetAttribute("value").Equals("Ashin Sabu"));
            Thread.Sleep(1000);

            // Field 2 Test: Reset Button Test
            webDriver.FindElement(resetButton).Click();
            Assert.IsTrue(
                firstNameFieldCheck.GetAttribute("value").Equals("") 
                && lastNameFieldCheck.GetAttribute("value").Equals("")
                && mobileNumberFieldCheck.GetAttribute("value").Equals("")
                && emailFieldCheck.GetAttribute("value").Equals("")
            );
            Thread.Sleep(1000);

            // Field 3 Test: Gender Radio Button Test
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

            // Field 4: Upload file test
            // IMPORTANT: Change the file path if you wish to run the test locally
            webDriver.FindElement(fileUploadField).SendKeys("C:/Users/Ashin/Desktop/ashin.jpg");
            Assert.IsTrue((bool)jse.ExecuteScript("" +
                "let fileField = document.querySelectorAll(`input[type='file']`); " +
                "if(fileField[0].files.length == 0) " +
                "return false; " +
                "else " +
                "return true;"));


            webDriver.Quit();

        }
    }
}
