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
    public class BrowserPage : BasePage
    {
        private IWebElement _text => Driver.FindElement(By.Id("primary-detection"));
        public BrowserPage(IWebDriver webdriver) : base(webdriver) { }

        public void VerifyChrome()
        {
            Assert.IsTrue("Chrome 89 on Windows 10".Equals(_text.Text));
        }

        public void VerifyMozilla()
        {
            Assert.IsTrue("Firefox 87 on Windows 10".Equals(_text.Text));
        }
    }
}
