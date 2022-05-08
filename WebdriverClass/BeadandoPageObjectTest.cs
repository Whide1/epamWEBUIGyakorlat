using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdriverClass.Beadando;
using System.Threading;
using System.Xml.Linq;
using System.Collections;

namespace WebdriverClass
{
    class BeadandoPageObjectTest : TestBase
    {
        [Test, TestCaseSource(nameof(SummonerTestData))]
        public void SummonerSearchTest(string name)
        {
            OPGGSearchPage page = OPGGSearchPage.Navigate(Driver);
            var summary = OPGGSearchPage.Navigate(Driver).GetSearchWidget().EnterSummonerName(name).GetSummonerWidget().SummaryText();

            // Summary megjelenik, így biztosan vagyunk benne hogy sikeresen tovább jutottunk
            Assert.AreEqual(summary, "Summary");
        }

        //[Test]
        //public void ToFailTest()
        //{
        //    OPGGSearchPage page = OPGGSearchPage.Navigate(Driver);
        //    var summary = OPGGSearchPage.Navigate(Driver).GetSearchWidget().EnterSummonerName("Whide").GetSummonerWidget().SummaryText();

        //    // Ez elfog hasalni, hiszen a Page osztályban a Cookie-ban a nyelvet beállítjuk angolra.
        //    Assert.AreEqual(summary, "Összegzés");
        //}

        static IEnumerable SummonerTestData()
        {
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\summoners.xml");
            return
                from vars in doc.Descendants("summoner")
                let name = vars.Attribute("name").Value
                select new object[] { name};
        }
    }
}
