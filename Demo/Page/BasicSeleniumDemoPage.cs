using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsWebdriver.Page
{
    public class BasicSeleniumDemoPage
    {
        private static IWebDriver _driver;

        private IWebElement _usernameInputField => _driver.FindElement(By.Id("user-message"));
        private IWebElement _showMessageButton => _driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement _resultFromPage => _driver.FindElement(By.Id("display"));
        private IWebElement _firstInputField => _driver.FindElement(By.Id("sum1"));
        private IWebElement _secondInputField => _driver.FindElement(By.Id("sum2"));
        private IWebElement _getTotalButton => _driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement _sumResultFromPage => _driver.FindElement(By.Id("displayvalue"));
        
        public BasicSeleniumDemoPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public void InsertTextToInputField(string text)
        {
            _usernameInputField.Clear();
            _usernameInputField.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            _showMessageButton.Click();
        }

        public void VerifyResult(string result)
        {
            Assert.AreEqual(result, _resultFromPage.Text, "Text is not the same");
        }

        public void InsertBothValuesToInputFields(string firstInput, string secondInput)
        {
            InsertTextToFirstInputField(firstInput);
            InsertTextToSecondInputField(secondInput);
        }
        public void ClickGetTotalButton()
        {
            _getTotalButton.Click();
        }

        public void VerifySumResult(string result)
        {
            Assert.AreEqual(result, _sumResultFromPage.Text, "Result is NOK");
        }

        private void InsertTextToFirstInputField(string text)
        {
            _firstInputField.Clear();
            _firstInputField.SendKeys(text);
        }

        private void InsertTextToSecondInputField(string text)
        {
            _secondInputField.Clear();
            _secondInputField.SendKeys(text);
        }
    }
}
