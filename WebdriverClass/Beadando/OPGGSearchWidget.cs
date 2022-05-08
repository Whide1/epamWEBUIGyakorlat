using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.Beadando
{
    public class OPGGSearchWidget : BasePage
    {
        private WebDriverWait wait;

        public OPGGSearchWidget(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        public IWebElement SearchBar => 
                        wait.Until(d=>d.FindElement(By.CssSelector("input[class='css-1k7wk8z e4p0i2v2']")));



        private void SetSummoner(string summonerName)
        {
            SearchBar.SendKeys(summonerName);
        }

        public OPGGSearchPage EnterSummonerName(string summonerName)
        {
            SetSummoner(summonerName);

            SearchBar.SendKeys(Keys.Enter);

            return new OPGGSearchPage(Driver);
        }
    }
}
