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
        public void ChangePageZoom()
        {
            Action changePageZoom = () => ((IJavaScriptExecutor)Driver).ExecuteScript("document.body.style.zoom='90%';");
            changePageZoom();
        }
        public void ExecuteScroll()
        {
            Action scrollAction = () => ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0, 5000);");
            scrollAction();
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
