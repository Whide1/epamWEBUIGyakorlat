using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace WebdriverClass
{
    class CookieTestAtClass : TestBase
    {
        String cookieName = "visitorid";

        [Test]
        public void TestVisitorCookie()
        {
            //Delete all cookies
            Driver.Navigate().GoToUrl("http://bookline.hu/");

            // Get visitorid cookie from bookline page
            Cookie cookieUnderTest = Driver.Manage().Cookies.GetCookieNamed("visitorid");
            Assert.IsNotNull(cookieUnderTest);
            PrintCookieInfo(cookieUnderTest);

            SearchForBook("Szent Johanna Gimi");
            // Get visitorid cookie again from bookline page
            Cookie updatedCookie = Driver.Manage().Cookies.GetCookieNamed("visitorid"); ;
            Assert.IsNotNull(updatedCookie);

            // verify that the VALUE of the 'visitorid' cookie is still the same
            Assert.AreEqual(cookieUnderTest.Name, updatedCookie.Name);

            // verify that the EXPIRATION DATE of the 'visitorid' cookie is still the same
            Assert.AreNotEqual(cookieUnderTest.Expiry, updatedCookie.Expiry);
        }

        [Test]
        public void TestCookieDeletion()
        {
            Driver.Navigate().GoToUrl("http://bookline.hu/");

            // Get visitorid cookie from bookline page
            Cookie cookieUnderTest = Driver.Manage().Cookies.GetCookieNamed("visitorid");
            Assert.IsNotNull(cookieUnderTest);
            PrintCookieInfo(cookieUnderTest);

            // Save cookieundertest value
            String originalValue = cookieUnderTest.Value;
            Assert.IsTrue(originalValue.Length > 0);

            // Delete visitorid cookie
            Driver.Manage().Cookies.DeleteAllCookies();
            // Verifiy that visitorid cookie is missing by getting a null
            Assert.IsNull(Driver.Manage().Cookies.GetCookieNamed("visitorid"));

            SearchForBook("Szent Johanna Gimi");
            // Get visitorid cookie from bookline page again
            Cookie recreatedCookie = Driver.Manage().Cookies.GetCookieNamed("visitorid");
            PrintCookieInfo(recreatedCookie);

            // verify that the original and recreated cookie value is different
            Assert.AreNotEqual(originalValue, recreatedCookie.Value);
        }

        private void PrintCookieInfo(Cookie testedCookie)
        {
            Console.Write("\n*******************************************************************\n");
            Console.Write("NAME: " + testedCookie.Name +
                    "\nVALUE: " + testedCookie.Value +
                    "\nEXPIRY: " + testedCookie.Expiry +
                    "\nDOMAIN " + testedCookie.Domain +
                    "\nPATH " + testedCookie.Path +
                    "\nIS SECURE: " + testedCookie.Secure);
            Console.Write("\n*******************************************************************\n");
        }

        private void SearchForBook(String bookName)
        {
            var search_field = Driver.FindElement(By.Name("searchfield"));
            search_field.SendKeys(bookName);
            search_field.Submit();
            Thread.Sleep(200);
        }
    }
}
