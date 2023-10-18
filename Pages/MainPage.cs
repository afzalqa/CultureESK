using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Pages
{
    public class MainPage : PageBase
    {
        private By alert = By.CssSelector(".content-block.huge-title");
        private By userName = By.XPath("//input[@name='login']");
        private By password = By.XPath("//input[@name='password']");
        private By signBtn = By.XPath("//span[@class='dx-button-text']");

        private By cashierAlert = By.CssSelector(".content-block");
        private By invalidCredsAlert = By.XPath("//span[@class='dx-field-item-label-text' and text()='Некорректный логин или пароль']");
        private By emptyFieldAlert = By.XPath("//span[@class='dx-field-item-label-text' and text()='Заполните все поля']");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }
        public void CheckThatAlertMsgContainsText(string text)
        {
            Assert.That(GetText(alert).Contains(text));
        }

        public void CheckThatCashierAlertMsgContainsText(string text)
        {
            Assert.True(GetText(cashierAlert).Contains(text));
        }

        public void CheckThatInvalidCredsAlert(string text)
        {
            Assert.True(GetText(invalidCredsAlert).Contains(text));
        }

        public void CheckThatEmptyFieldAlert(string text)
        {
            Assert.True(GetText(emptyFieldAlert).Contains(text));
        }

        public void LoginWithNameAndPassword(string login, string pwd)
        {
            Clear(userName);
            SendKeys(userName, login);
            Clear(password);
            SendKeys(password, pwd);
            Click(signBtn);
        }
    }
}
