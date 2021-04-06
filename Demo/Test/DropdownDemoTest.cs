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
    public class DropdownDemoTest
    {
        private static DropdownDemoPage _page;
        private static List<string> stateList = new List<string> { "", "" };

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new DropdownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [TestCase("Florida", TestName = "First selected Ohio")]
        [TestCase("California", TestName = "First selected California")]
        //public static void MultipleDropdownFirstSelectedTest(params string[] states)

        public static void MultipleDropdownFirstSelectedTest(string states)
        {
            List<string> state = states.Split(',').ToList();
            _page.SelectFromMultipleDropdown(state);
            _page.ClickFirstSelectedButton();
            _page.VerifyFirstSelectedState(state[0]);
        }

        public static void MultipleDropdownAllSelectedTest()
        {
            List<string> elements = new List<string> { "Ohio", "Florida", "California" };
            _page.SelectFromMultipleDropdown(elements);
            _page.ClickGetAllSelectedButton();
            _page.VerifyFirstSelectedState(elements[0]);
        }
    }
}
