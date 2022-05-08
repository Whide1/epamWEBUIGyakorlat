using OpenQA.Selenium;
using WebdriverClass.WidgetsAtClass;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.Beadando
{
    public class OPGGSearchPage : BasePage
    {
        public OPGGSearchPage(IWebDriver driver) : base(driver)
        {

        }

        public static OPGGSearchPage Navigate(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("https://eune.op.gg/");
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Cookies.AddCookie(new Cookie("customLocale","en_US"));
            Driver.Manage().Cookies.AddCookie(new Cookie("_ol","en_US"));
            Driver.Navigate().Refresh();
            return new OPGGSearchPage(Driver);
        }

        public OPGGSummonerWidget GetSummonerWidget()
        {
            return new OPGGSummonerWidget(Driver);
        }

        public OPGGSearchWidget GetSearchWidget()
        {
            return new OPGGSearchWidget(Driver);
        }
    }
}
