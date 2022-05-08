using OpenQA.Selenium;

namespace WebdriverClass.PagesAtClass
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
    }
}
