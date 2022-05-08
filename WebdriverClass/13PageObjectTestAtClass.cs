using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchWidget = WebdriverClass.WidgetsAtClass.SearchWidget;
using ResultWidget = WebdriverClass.WidgetsAtClass.ResultWidget;
using WebdriverClass.PagesAtClass;
using WebdriverClass.WidgetsAtClass;

namespace WebdriverClass
{
    class PageObjectTestAtClass : TestBase
    {
        [Test]
        public void PageObjectSearchExample()
        {
            // TASK 1.1: implement a static navigate function to search page which returns a search page instance
            // TASK 1.2: implement GetSearchWidget function and instantiate searchWidget 
            SearchWidget searchWidget = SearchPage.navigate(Driver).GetSearchWidget();

            // TASK 2.1: search for route from "Budapest" to "Szeged" via "Kecskemet" using searchWidget
            // TASK 2.2: set reduction to "Tanuló bérlet" using searchWidget
            // TASK 2.3: set search option to SearchWidget.searchOptions.PotjegyNelkul
            SearchModel searchModel = new SearchModel()
            {
                FromCity = "Budapest",
                ToCity = "Szeged",
                ViaCity = "Kecskemét",
                Reduction = SearchWidget.Reductions.TanuloBerlet,
                SearchOption = SearchWidget.SearchOptions.PotjegyNelkul
            };
            SearchPage resultPage = searchWidget.SearchFor(searchModel);
            // TASK 3.1: implement searchWidget's ClickTimetableButton function to click on Menetrend button and return a search page instance
            ResultWidget resultWidget = resultPage.GetResultWidget();
            // TASK 3.2: implement GetResultWidget function and instantiate resultWidget 
            // TASK 4.1: Finish ResultWidget to give back the number of results
            Assert.Greater(resultWidget?.GetNoOfResults(), 0);
        }
        [Test]
        public void RefactoredPageObjectSearchExample()
        {
            SearchModel searchModel = new SearchModel()
            {
                FromCity = "Budapest",
                ToCity = "Szeged",
                ViaCity = "Kecskemét",
                Reduction = SearchWidget.Reductions.TanuloBerlet,
                SearchOption = SearchWidget.SearchOptions.PotjegyNelkul
            };

            var results = SearchPage.navigate(Driver).GetSearchWidget().SearchFor(searchModel).GetResultWidget().GetNoOfResults();

            Assert.Greater(results, 0);
        }
    }
}
