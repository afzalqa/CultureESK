using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CultureESK.Pages
{
    public class KassaPage : PageBase
    {
        private By surnameInput = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By nameInput = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By middleNameInput = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By OldPasswordInput = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By NewPasswordInput = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        public By SaveButton = By.XPath("//span[@class='dx-button-text' and text()='Сохранить']");
        public By CancelButton = By.XPath("//span[@class='dx-button-text' and text()='Отменить']");
        public By ScanQrCodeButton = By.XPath("(//span[@class='dx-button-text'])[1]");

        //Assert
        private By PointCameraQrCodeTitle = By.CssSelector(".qr-scanner-text");
        public KassaPage(IWebDriver driver) : base(driver) {}

        public void CheckThatQrCodeTitle(string text)
        {
            Assert.True(GetText(PointCameraQrCodeTitle).Contains(text));
        }
        public void EditKassaProfile(string Surname, string Name, string MiddleName, string OldPassword, string NewPassword, By element)
        {
            Clear(surnameInput);
            SendKeys(surnameInput, Surname);
            Clear(nameInput);
            SendKeys(nameInput, Name);
            Clear(middleNameInput);
            SendKeys(middleNameInput, MiddleName);
            Clear(OldPasswordInput);
            SendKeys(OldPasswordInput, OldPassword);
            Clear(NewPasswordInput);
            SendKeys(NewPasswordInput, NewPassword);
            Click(element);
            Thread.Sleep(4000);
        }

        public void ClickScanQrCodeButton() 
        {
            Click(ScanQrCodeButton);
        }

    }
}
