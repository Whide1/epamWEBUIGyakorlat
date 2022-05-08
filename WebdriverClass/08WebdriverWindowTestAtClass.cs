using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;

namespace WebdriverClass
{
    class WebdriverWindowTestAtClass : TestBase
    {
        [Test]
        public void ResponsiveWindow()
        {
            Driver.Navigate().GoToUrl("http://www.expedia.com/");
            //Maximize browser window
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            // Hoppá ezek már nem igazán működnek
            //Assert.IsTrue(Driver.FindElement(By.Id("header-account-menu")).Displayed);
            //Assert.IsFalse(Driver.FindElement(By.Id("header-mobile-toggle")).Displayed);
            //Set browser window size to 600x600
            Driver.Manage().Window.Size = new Size(600, 600);
            Thread.Sleep(2000);
            //Assert.IsTrue(Driver.FindElement(By.Id("header-mobile-toggle")).Displayed);
            //Assert.IsFalse(Driver.FindElement(By.Id("header-account-menu")).Displayed);
        }

        [Test]
        public void MultipleWindow()
        {
            // have to use Chrome because of SHIFT+Click, so Driver is overwritten
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.amazon.com/gp/gw/ajax/s.html");
            // String mainWindow <= save current window's handle in this string
            string mainWindow = Driver.CurrentWindowHandle;
            new Actions(Driver).KeyDown(Keys.Shift).Click(Driver.FindElement(By.CssSelector("a[href*='cart']"))).KeyUp(Keys.Shift).Perform();
            // ReadOnlyCollection<string> windows <= save all window handles here
            ReadOnlyCollection<string> windows = Driver.WindowHandles;
            // Switch to last opened window
            Driver.SwitchTo().Window(windows[windows.Count - 1]);
            StringAssert.Contains("Cart", Driver.Title);
            // Close active window
            Driver.Close();
            // Switch to our main window
            Driver.SwitchTo().Window(mainWindow);
            Assert.IsTrue(Driver.FindElement(By.Id("gw-card-layout")).Displayed);
        }


    }
}
