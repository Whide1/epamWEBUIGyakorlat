using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebdriverClass
{
    class WebdriverWaitTestAtClass : TestBase
    {
        [Test]
        public void WaitTitle()
        {

            Driver.Navigate().GoToUrl("http://www.google.hu");

            Driver.Manage().Cookies.AddCookie(new Cookie("CONSENT", "YES+HU.hu+V12+BX"));

            Driver.Navigate().Refresh();
            IWebElement query = Driver.FindElement(By.Name("q"));
            query.SendKeys("Selenium");
            query.Submit();

            //create a WebDriverWait which waits until the page title starts with "Selenium"
            Assert.AreEqual("Selenium - Google-keresés", Driver.Title);
        }

        [Test]
        public void WaitKeyboard()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");
            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl("http://www.google.hu");
            Driver.Manage().Cookies.AddCookie(new Cookie("CONSENT", "YES+HU.hu+V12+BX"));
            Driver.Navigate().Refresh();

            //Driver.FindElement(By.Id("gs_ok0")).Click();
            Driver.FindElement(By.ClassName("Umvnrc")).Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            //wait until the keyboard is shown
            //var keyboard = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("kbd")));
            wait.Until(d => d.FindElement(By.Id("kbd")).Displayed);

            Driver.FindElement(By.Id("K81")).Click(); //this clicks on q key on keyboard

            Driver.FindElement(By.ClassName("Umvnrc")).Click();
            // Ez kellett nekem még
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("btnK")));

            Driver.FindElement(By.Name("btnK")).Click();

            Assert.AreEqual("q - Google-keresés", Driver.Title);
        }
    }
}