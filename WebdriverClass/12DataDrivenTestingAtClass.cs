using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using OpenQA.Selenium.Chrome;
using WebdriverClass;

namespace WebdriverClass
{
    class DataDrivenTestingAtClass : TestBase
    {
        // Expand test attributes - localizationData
        [Test, TestCaseSource(nameof(LocalizationData))]
        public void LocalizationXMLTest(String lang, String text)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=" + lang);
            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl("http://elvira.mav-start.hu/");
            var timetableText = Driver.FindElement(By.Name("go")).GetAttribute("value");
            Console.WriteLine(timetableText);
            StringAssert.Contains(timetableText, text);
        }

        // Expand test attributes - testData
        [Test, TestCaseSource(nameof(TestData))]
        public void XMLTest(String country, String desc)
        {

            Driver.Navigate().GoToUrl("http://en.wikipedia.org/wiki/Main_Page");
            Driver.FindElement(By.Id("searchInput")).Clear();
            Driver.FindElement(By.Id("searchInput")).SendKeys(country);
            Driver.FindElement(By.Id("searchButton")).Click();
            String officialName = Driver.FindElement(By.ClassName("country-name")).Text;
            Console.WriteLine(officialName);
            Assert.True(desc.Equals(officialName.Trim()));
        }

        static IEnumerable LocalizationData()
        {
            // Open and read the contents of localization.xml like data.xml below
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\localization.xml");

            return from vars in doc.Descendants("localizationData")
                   let language = vars.Attribute("lang").Value
                   let text = vars.Attribute("text").Value
                   select new object[] { language, text };
        }

        static IEnumerable TestData()
        {
            var doc = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "\\data.xml");
            return
                from vars in doc.Descendants("testData")
                let country = vars.Attribute("country").Value
                let desc = vars.Attribute("desc").Value
                select new object[] { country, desc };
        }
    }
}
