using AngleSharp.Dom;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Pages
{
    public class SectionsHelper : PageBase
    {
        private By alert = By.CssSelector(".content-block.huge-title");
        private By userName = By.XPath("//input[@name='login']");
        private By password = By.XPath("//input[@name='password']");
        private By signBtn = By.XPath("//span[@class='dx-button-text']");

        //Sections
        public By ManagmentSection = By.CssSelector(".dx-icon.fas.fa-landmark");
        public By ProductsAndServicesSection = By.CssSelector(".dx-icon.fas.fa-box-open");
        public By AdministrationSection = By.CssSelector(".dx-icon.dx-icon-toolbox");
        public By ExitButton = By.CssSelector(".dx-icon.fas.fa-door-open");
        public By ProfileButton = By.CssSelector(".dx-icon.dx-icon-user");

        //Assert
        private By FacilityTitle = By.CssSelector(".content-block.admin-title");
        private By ProductsAndServicesTitle = By.CssSelector(".content-block.product-title");
        private By AdministrationTitle = By.CssSelector(".content-block.admin-title");
        private By AuthorizationTitle = By.CssSelector(".title");
        private By EnteringESKNumberTitle = By.CssSelector(".content-block");
        private By EditProfileTitle = By.CssSelector(".content-block.slim-header");

        public SectionsHelper(IWebDriver driver) : base(driver) { }

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

        public void CheckThatAdministrationTitle(string text)
        {
            Assert.True(GetText(AdministrationTitle).Contains(text));
        }

        public void CheckThatAuthorizationTitle(string text)
        {
            Assert.True(GetText(AuthorizationTitle).Contains(text));
        }

        public void CheckThatEnteringESKNumberTitle(string text)
        {
            Assert.True(GetText(EnteringESKNumberTitle).Contains(text));
        }

        public void CheckThatEditProfileTitle(string text)
        {
            Assert.True(GetText(EditProfileTitle).Contains(text));
        }

        public void LoginWithNameAndPassword(string login, string pwd)
        {
            Clear(userName);
            SendKeys(userName, login);
            Clear(password);
            SendKeys(password, pwd);
            Click(signBtn);
        }

        public void LoginAsManagmentAndSwitch(string login, string pwd, By element)
        {
            Clear(userName);
            SendKeys(userName, login);
            Clear(password);
            SendKeys(password, pwd);
            Click(signBtn);
            Click(element);
        }
    }
}
