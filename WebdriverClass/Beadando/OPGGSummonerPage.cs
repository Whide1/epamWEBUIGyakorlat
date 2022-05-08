using OpenQA.Selenium;
using WebdriverClass.WidgetsAtClass;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.Beadando
{
    class OPGGSummonerPage : BasePage
    {
        public OPGGSummonerPage(IWebDriver driver) : base(driver)
        {

        }

        public static OPGGSearchPage Navigate(IWebDriver Driver, string summonerName)
        {
            Driver.Navigate().GoToUrl("https://eune.op.gg/summoners/eune/" + summonerName);

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
