using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class SearchWidget : BasePage
    {
        public SearchWidget(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SearchBottom => Driver.FindElement(By.Id("searchbottom"));
        public IWebElement RouteFrom => Driver.FindElement(By.Id("i"));
        public IWebElement RouteTo => Driver.FindElement(By.Id("e"));
        public IWebElement RouteVia => Driver.FindElement(By.Id("v"));
        public IWebElement ReductionSlct => Driver.FindElement(By.Id("u"));
        public IWebElement SearchButton => Driver.FindElement(By.Name("go"));

        Dictionary<SearchOptions, string> searchOptionLocators = new Dictionary<SearchOptions, string>()
        {
            { SearchOptions.PotjegyNelkul , "s1" },
            { SearchOptions.AtszallasNelkul , "sk" },
            { SearchOptions.HelyiKozlekedesNelkul , "hkn" },
            { SearchOptions.BudapestBerlettel , "sb" },
            { SearchOptions.Kerekparral , "s2" },
            { SearchOptions.BudapestFejpalyaudvaronAt , "s1" }
        };

        Dictionary<Reductions, string> reductionLocators = new Dictionary<Reductions, string>()
        {
            { Reductions.TanuloBerlet, "1161" }
        };

        public enum SearchOptions
        {
            PotjegyNelkul,
            AtszallasNelkul,
            HelyiKozlekedesNelkul,
            BudapestBerlettel,
            Kerekparral,
            BudapestFejpalyaudvaronAt,
        }

        public enum Reductions
        {
            TanuloBerlet
        }

        public void SetRoute(String fromCity, String toCity)
        {
            RouteFrom.SendKeys(fromCity);
            RouteTo.SendKeys(toCity);
        }
        
        public void SetRoute(String fromCity, String toCity, String viaCity)
        {
            SetRoute(fromCity, toCity);
            RouteVia.SendKeys(viaCity);
        }

        public void SetReduction(Reductions reduction){
            new SelectElement(ReductionSlct).SelectByValue(reductionLocators[reduction]);
	    }

        public void SetSearchOptionTo(SearchOptions searchOption)
        {
            SearchBottom.FindElement(By.Id(searchOptionLocators[searchOption])).Click();
	    }
        public SearchPage SearchFor(SearchModel model)
        {
            SetRoute(model.FromCity, model.ToCity);
            SetReduction(model.Reduction);
            SetSearchOptionTo(model.SearchOption);


            return ClickTimetableButton();
        }
        // TASK 3.1: implement searchWidget's ClickTimetableButton function to click on Menetrend button and return a search page instance
        public SearchPage ClickTimetableButton()
        {
            SearchButton.Click();

            return new SearchPage(Driver);
        }
    }
}
