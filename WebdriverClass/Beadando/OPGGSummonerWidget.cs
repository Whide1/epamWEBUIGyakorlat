using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.Beadando
{
    public class OPGGSummonerWidget : BasePage
    {
        private WebDriverWait wait;

        public OPGGSummonerWidget(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }


        /// <summary>
        /// The Summary button.
        /// </summary>
        private IWebElement summary => wait.Until(d => d.FindElement(By.CssSelector("a[class='css-1a8o8sd e1ijocqp1']")));

        /// <summary>
        /// The middle section of the site.
        /// </summary>
        private IWebElement middle => wait.Until(d => d.FindElement(By.CssSelector("div[class='css-1sq1kbv e3mqlfu0']")));

        /// <summary>
        /// The List of Matches played by the Summoner
        /// Ez nem igazán akart működni, valami baja van biztosan azzal, hogy út közben a JS tölti be a dolgokat.
        /// </summary>
        public List<IWebElement> Matches => wait.Until(d => d.FindElements(By.CssSelector("li[class='css-ja2wlz e19epo2o3']"))).ToList();

        public IWebElement ChampionTab => wait.Until(d => d.FindElement(By.CssSelector("span[type='champion']")));

        public int QueriedMatchesNumber()
        {
            return Matches.Count;
        }
        public string SummaryText()
        {
            return summary.Text;
        }

    }
}
