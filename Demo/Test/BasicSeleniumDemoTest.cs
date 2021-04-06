using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace Demo.Test
{
    public class BasicSeleniumDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]

        public static void BasicInputField()
        {
            BasicSeleniumDemoPage page = new BasicSeleniumDemoPage(_driver);

            string text = "kaciukai";

            page.InsertTextToInputField(text);
            page.ClickShowMessageButton();
            page.VerifyResult(text);
        }

            [TestCase("2", "2", "4", TestName = "2 plius 2 = 4")]
            [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
            [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]

            public static void TestSum(string firstInput, string secondInput, string result)
            {
                BasicSeleniumDemoPage page = new BasicSeleniumDemoPage(_driver);
                page.InsertBothValuesToInputFields(firstInput, secondInput);
                page.ClickGetTotalButton();
                page.VerifySumResult(result);
            }
        }
    
}
