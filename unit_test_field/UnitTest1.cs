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
            By textField = By.XPath("//input[@type='text']");
            By genderRadioButtons = By.XPath("//input[@type='radio']");
            By resetButton = By.XPath("//button[@type='reset']");
            By fileUploadField = By.XPath("//input[@type='file']");

            var chromeOptions = new ChromeOptions();

            // UNCOMMENT FOLLOWING LINE IF YOU WISH TO RUN TESTS IN HEADLESS MODE

            //chromeOptions.AddArguments("headless");

            

            IWebDriver webDriver = new ChromeDriver(chromeOptions);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            IJavaScriptExecutor jse = (IJavaScriptExecutor)webDriver;

            var textFieldsCheck = webDriver.FindElements(textField);

            // Field 1 Test: First Name Field Test
            webDriver.FindElements(textField)[0].SendKeys("Ashin Sabu");
            Assert.IsTrue(textFieldsCheck[0].GetAttribute("value").Equals("Ashin Sabu"));
            Thread.Sleep(1000);

            // Field 2 Test: Reset Button Test
            webDriver.FindElement(resetButton).Click();
            Assert.IsTrue(
                textFieldsCheck[0].GetAttribute("value").Equals("") &&
                textFieldsCheck[1].GetAttribute("value").Equals("") &&
                textFieldsCheck[2].GetAttribute("value").Equals("") &&
                textFieldsCheck[3].GetAttribute("value").Equals("") &&
                textFieldsCheck[4].GetAttribute("value").Equals("") 
            );
            Thread.Sleep(1000);

            // Field 3 Test: Gender Radio Button Test
            var genderRadioButtonsCheck = webDriver.FindElements(genderRadioButtons);

            webDriver.FindElements(genderRadioButtons)[0].Click();
            Assert.IsTrue((genderRadioButtonsCheck[1].Selected == false && genderRadioButtonsCheck[2].Selected == false));
            Thread.Sleep(1000);

            webDriver.FindElements(genderRadioButtons)[1].Click();
            Assert.IsTrue((genderRadioButtonsCheck[0].Selected == false && genderRadioButtonsCheck[2].Selected == false));
            Thread.Sleep(1000);

            webDriver.FindElements(genderRadioButtons)[2].Click();
            Assert.IsTrue((genderRadioButtonsCheck[0].Selected == false && genderRadioButtonsCheck[1].Selected == false));
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
            Thread.Sleep(1000);

            webDriver.Quit();

        }
    }
}
