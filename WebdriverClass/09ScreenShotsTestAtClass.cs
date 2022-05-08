using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.IO;

namespace WebdriverClass
{
    class ScreenShotsTestAtClass : TestBase
    {
        [Test]
        public void ScreenShots()
        {
            Driver.Navigate().GoToUrl("http://www.elvira.hu");
            
            //string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\screenshot\\"));
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string screenshotName = baseDirectory +
                                    TestContext.CurrentContext.Test.Name +
                                    "_" +
                                    DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")+
                                    "_error.png";

            //Maximize browser window
            Driver.Manage().Window.Maximize();
            //Create a screenshot and save the file as screenshot.png
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
            Assert.IsTrue(File.Exists(screenshotName));
        }
    }
}
