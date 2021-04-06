using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace Demo.Page
{
    public class CheckboxPage : BasePage
    {
        private const string _pageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private IWebElement _clickButton => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _text => Driver.FindElement(By.Id("txtAge"));
        private IWebElement _resultButton => Driver.FindElement(By.Id("check1"));
        private IReadOnlyCollection<IWebElement> multipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));

        public CheckboxPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAddress;
        }

        public void ClickOneCheckbox()
        {
            if (!_clickButton.Selected)
                _clickButton.Click();
        }

        public void VerifyResult()
        {
            Assert.IsTrue("Success - Check box is checked".Equals(_text.Text));
        }

        public void ClickAllCheckbox()
        {
            if (_clickButton.Selected)
                _clickButton.Click();

            foreach (IWebElement checkbox in multipleCheckboxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
        }
        public void VerifyResultButton()
        {
            Assert.AreEqual("Uncheck All", _resultButton.GetAttribute("value"), "Value is not correct");
        }

        public void ClickUncheckAll()
        {
            if (_clickButton.Selected)
                _clickButton.Click();

            IReadOnlyCollection<IWebElement> multipleCheckboxList = Driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in multipleCheckboxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
            _resultButton.Click();
        }

        public void VerifyResultButtonAgain()
        {
            Assert.AreEqual("Check All", _resultButton.GetAttribute("value"), "Value is not correct");
        }
    }


}
