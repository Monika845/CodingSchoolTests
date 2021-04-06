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
    public class DropdownHomeworkTest
    {
        private static DropdownHomeworkPage _page;
        private static List<string> stateList = new List<string> { "", "" };

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new DropdownHomeworkPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [TestCase("Florida", "New York", TestName = "First selected Florida")]
        public static void MultipleDropdownFirstSelectedTest(params string[] states)
        {
            _page.SelectFromMultipleDropdown(states.ToList());
            _page.ClickFirstSelectedButton();
            _page.VerifyFirstSelectedState(states[0]);
        }

        [TestCase("Pennsylvania", "New Jersey", TestName = "Options selected are: Pennsylvania, New Jersey")]
        public static void MultipleDropdownAllSelectedTest(params string[] states)
        {
            _page.SelectFromMultipleDropdown(states.ToList());
            _page.ClickGetAllSelectedButton();
            _page.VerifyFirstSelectedState(states[0]);
        }


    }
}
