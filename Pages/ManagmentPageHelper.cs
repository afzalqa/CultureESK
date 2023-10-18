using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Pages
{
    public class ManagmentPageHelper : PageBase
    {
        private By alert = By.CssSelector(".content-block.huge-title");
        private By userName = By.XPath("//input[@name='login']");
        private By password = By.XPath("//input[@name='password']");
        private By signBtn = By.XPath("//span[@class='dx-button-text']");

        private By FacilityTitle = By.CssSelector(".content-block.admin-title");
        private By ProductsAndServicesTitle = By.CssSelector(".content-block.product-title");
        private By Managment = By.CssSelector(".dx-icon.fas.fa-landmark");

        public ManagmentPageHelper(IWebDriver driver) : base(driver) { }

        public void CheckThatAlertMsgContainsText(string text)
        {
            Assert.That(GetText(alert).Contains(text));
        }

        public void CheckThatFacilityTitle(string text)
        {
            Assert.True(GetText(FacilityTitle).Contains(text));
        }

        public void CheckThatProductsAndServicesTitle(string text)
        {
            Assert.True(GetText(ProductsAndServicesTitle).Contains(text));
        }

        public void LoginWithNameAndPassword(string login, string pwd)
        {
            Clear(userName);
            SendKeys(userName, login);
            Clear(password);
            SendKeys(password, pwd);
            Click(signBtn);
        }

        public void LoginAsManagmentAndSwitch(string login, string pwd)
        {
            Clear(userName);
            SendKeys(userName, login);
            Clear(password);
            SendKeys(password, pwd);
            Click(signBtn);
            Click(Managment);
        }
    }
}
