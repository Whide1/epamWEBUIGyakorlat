using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverClass
{
    class ListBoxCheckBoxTestAtClass : TestBase
    {
        [Test]
        public void ListBoxCheckBoxExample()
        {
            Driver.Navigate().GoToUrl("http://elvira.mav-start.hu/elvira.dll/x/index?language=2");
            Driver.FindElement(By.Id("i")).SendKeys("Budapest");
            Driver.FindElement(By.Id("e")).SendKeys("Balatonfüred");

            // Choose "Youth under 26" with children from Reduction listbox
            new SelectElement(Driver.FindElement(By.CssSelector("select[id='u']"))).SelectByValue("1133");
            // Set "without surcharge" checkbox from search Options
            Driver.FindElement(By.Id("s1")).Click();
            Driver.FindElement(By.Name("uff")).Submit();
            StringAssert.Contains("Youth under 26", Driver.FindElement(By.ClassName("t")).Text);
        }
    }
}
