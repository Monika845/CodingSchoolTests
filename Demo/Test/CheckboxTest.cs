using Demo.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class CheckboxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void OneCheckbox()
        {
            CheckboxPage page = new CheckboxPage(_driver);
            page.ClickOneCheckbox();
            page.VerifyResult();
        }

        [Test]
        public static void MultipleCheckbox()
        {
            CheckboxPage page = new CheckboxPage(_driver);
            page.ClickAllCheckbox();
            page.VerifyResultButton();
        }

        [Test]
        public static void UncheckAllCheckbox()
        {
            CheckboxPage page = new CheckboxPage(_driver);
            page.ClickUncheckAll();
            page.VerifyResultButtonAgain();

        }
    }
}
