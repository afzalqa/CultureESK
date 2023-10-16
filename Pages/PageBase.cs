using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Pages
{
    public class PageBase
    {
        public IWebDriver Driver;
        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement Element(By by)
        {
            return Driver.FindElement(by);
        }

        public void Click(By by)
        {
            Element(by).Click();
        }
        public void SendKeys(By by, string txt)
        {
            Element(by).SendKeys(txt);
        }
        public void Clear(By by) 
        {
            Element(by).Clear();
        }
        public string GetText(By by)
        {
            return Element(by).Text;
        }
    }
}
