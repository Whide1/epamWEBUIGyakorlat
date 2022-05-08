using OpenQA.Selenium;
using WebdriverClass.WidgetsAtClass;

namespace WebdriverClass.PagesAtClass
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        // TASK 1.1: implement a static navigate function to search page which returns a search page instance
        public static SearchPage navigate(IWebDriver webDriver)
        {
            // Navigate to "http://elvira.mav-start.hu/elvira.dll/x/index?language=1"
            webDriver.Navigate().GoToUrl("http://elvira.mav-start.hu/elvira.dll/x/index?language=1");
            return new SearchPage(webDriver);
            // Return new SearchPage instance
        }

        // TASK 1.2: implement getSearchWidget function
        public SearchWidget GetSearchWidget()
        {
            return new SearchWidget(Driver);
        }

        // TASK 3.2: implement getResultWidget function and instantiate resultWidget
        public ResultWidget GetResultWidget()
        {
            // Create new resultWidget
            return new ResultWidget(Driver);
        }
    }
}
