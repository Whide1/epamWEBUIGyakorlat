using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WebdriverClass
{
    [TestFixture]
    class TestBase
    {
        IWebDriver driver;

        public IWebDriver Driver
        {
            get
            { return driver; }
            set
            {
                driver.Quit();
                driver = value;
            }
        }

        /// <summary>
        /// Megmondjuk, hogy a Chrome-unkat milyen beállításokkal szeretnénk megnyitni. Ebben az esetben magyarul.
        /// </summary>
        [SetUp]
        protected void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");

            // Itt nyílik meg a böngésző.
            driver = new ChromeDriver(options);
        }

        [TearDown]
        protected void Teardown()
        {
            // Tesztelés végén nem záródna be a böngésző, ha ezt nem tesszük meg.
            driver.Quit();
        }
    }
}
