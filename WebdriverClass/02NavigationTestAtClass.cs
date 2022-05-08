using System;
using NUnit.Framework;

namespace WebdriverClass
{
    class NavigationTestAtClass : TestBase
    {
        private String assertTitleChange(String oldTitle)
        {
            String newTitle = Driver.Title;
            Assert.AreNotEqual(oldTitle, newTitle);
            return newTitle;
        }

        [Test]
        public void NavigationExample()
        {
            String title = "";
            //Navigate to https://www.google.com
            Driver.Navigate().GoToUrl("https://www.google.com");
            title = assertTitleChange(title);

            //Navigate to https://www.bing.com
            Driver.Navigate().GoToUrl("https://www.bing.com");
            title = assertTitleChange(title);

            //Navigate back
            Driver.Navigate().Back();
            title = assertTitleChange(title);

            //Navigate forward
            Driver.Navigate().Forward();
            title = assertTitleChange(title);

            //Refresh browser window
            Driver.Navigate().Refresh();
            Assert.AreEqual(title, Driver.Title);
            Assert.AreEqual("https://www.bing.com/", Driver.Url);
        }
    }
}
