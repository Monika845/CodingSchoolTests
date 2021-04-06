using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsWebdriver.Page
{
    public class DemoVTPage : BasePage
    {
        private IWebElement _widthInputField => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInputField => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckbox => Driver.FindElement(By.Id("automatika"));
        private IWebElement _worksCheckbox => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector(".col-md-12.alert.alert-success"));

        public DemoVTPage(IWebDriver webdriver) : base(webdriver) { }

        public void InsertWidth(string width)
        {
            _widthInputField.Clear();
            _widthInputField.SendKeys(width);
        }

        public void InsertHeight(string height)
        {
            _heightInputField.Clear();
            _heightInputField.SendKeys(height);
        }

        public void InsertWidthAndHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHeight(height);
        }

        public void CheckAutoCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _autoCheckbox.Selected)
                _autoCheckbox.Click();
        }

        public void CheckWorksCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _worksCheckbox.Selected)
                _worksCheckbox.Click();
        }

        public void ClickCalculateButton()
        {
            _calculateButton.Click();
        }

        public void CheckResult(string result)
        {
            WaitForElementToBeDisplayed(_resultBox);
            Assert.IsTrue(_resultBox.Text.Contains(result), $"Failed, expected result was {result}, but actual result was {_resultBox.Text}");
        }

        private void WaitForElementToBeDisplayed(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => element.Displayed);
        }
    }
}
