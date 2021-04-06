using Demo.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class BrowserTest
    {
        private static IWebDriver _driver;

        //BrowserPage page = new BrowserPage(_driver);

        [TearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestBrowserChrome()
        {
            
            _driver = new ChromeDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            BrowserPage page = new BrowserPage(_driver);
            page.VerifyChrome();
        }

        [Test]
        public static void TestBrowserMozilla()
        {
            
            _driver = new FirefoxDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            BrowserPage page = new BrowserPage(_driver);
            page.VerifyMozilla();
        }
    }
}
