using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebdriverClass.PagesAtClass;

namespace WebdriverClass.WidgetsAtClass
{
    public class ResultWidget : BasePage
    {
        public ResultWidget(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement timeTable => Driver.FindElement(By.Id("timetable"));
        // TASK 4.2: Create a new timetable webelement using FindsBy annotation
        public List<IWebElement> Lines => timeTable.FindElements(By.XPath(".//table/tbody/tr[@style]")).ToList();


        public int GetNoOfResults()
        {
            // TASK 4.3: Count the valid "tr" tags inside timetable webelement and return the number
            return Lines.Count;
        }
    }
}
