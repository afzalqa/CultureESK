using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace CultureESK.Base
{
    public class TestBase
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless"); // Включение Headless режима
            //для выключения режима headless нужно заккоментить 2 строки выше и раскомментить 1 ниже

            //driver = new ChromeDriver(options);
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test-culture.eskso.ru/login");

        }

        [TearDown]
        public void CleanUp() { driver.Close(); }
    }
}
