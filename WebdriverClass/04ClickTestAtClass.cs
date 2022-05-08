using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebdriverClass
{
    class ClickTestAtClass : TestBase
    {
        [Test]
        public void ClickExample()
        {
            Driver.Navigate().GoToUrl("https://stackoverflow.com/tags");
            //Click on Questions link (use Id selector)
            Driver.FindElement(By.Id("nav-questions")).Click();
            Assert.AreEqual("Newest Questions - Stack Overflow", Driver.Title);

            //Click on Tags link (use Id selector)
            Driver.FindElement(By.Id("nav-tags")).Click();
            Assert.AreEqual("Tags - Stack Overflow", Driver.Title);

            //Click on Stackoverflow logo link (use CssSelector selector)
            Driver.FindElement(By.CssSelector("a[class='s-topbar--logo js-gps-track']")).Click();
            StringAssert.Contains("Stack Overflow", Driver.Title);
        }

        [Test]
        public void ShiftClickExample()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.com/gp/gw/ajax/s.html");
            //Use Actions class to create a shift click on Cart link
            IWebElement cartLink =  Driver.FindElement(By.CssSelector("a[class='nav-a nav-a-2 nav-progressive-attribute']"));
            //a[id='nav-cart']


            //You have to see two browser windows after a successful run
            new Actions(Driver).KeyDown(Keys.Shift).Click(cartLink).KeyUp(Keys.Shift).Perform();
            Assert.AreEqual(2, Driver.WindowHandles.Count);
        }

        [Test]
        public void DragAndDropTestAtClass()
        {
            Driver.Navigate().GoToUrl("https://jqueryui.com/resources/demos/droppable/default.html");
            //Locate the draggable element
            IWebElement draggable = Driver.FindElement(By.Id("draggable"));
            //Locate the droppable element
            IWebElement droppable = Driver.FindElement(By.Id("droppable"));
            //Add the drag and drop action here
            new Actions(Driver).DragAndDrop(draggable, droppable).Perform();
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#droppable > p:nth-child(1)")).Text.Equals("Dropped!"));
        }
    }
}
