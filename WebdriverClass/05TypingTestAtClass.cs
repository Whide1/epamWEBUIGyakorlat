using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebdriverClass
{
    class TypingTestAtClass : TestBase
    {
        [Test]
        public void TypeExample()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.Manage().Cookies.AddCookie(new Cookie("CONSENT", "YES+HU.hu+V12+BX"));
            Driver.Navigate().Refresh();
            IWebElement searchField = Driver.FindElement(By.Name("q"));
            // Type selenium word to google search field
            searchField.SendKeys("Selenium");
            Assert.AreEqual("Selenium", searchField.GetAttribute("value"));

            // Clear google search field
            searchField.Clear();
            Assert.IsEmpty(searchField.GetAttribute("value"));
        }
    }
}
