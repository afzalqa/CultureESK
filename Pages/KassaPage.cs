using OpenQA.Selenium;

namespace CultureESK.Pages
{
    public class KassaPage : PageBase
    {
        private By surnameInput = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By nameInput = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By middleNameInput = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By OldPasswordInput = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By NewPasswordInput = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        public By SaveBtn = By.XPath("//span[@class='dx-button-text' and text()='Сохранить']");
        public By CancelBtn = By.XPath("//span[@class='dx-button-text' and text()='Отменить']");
        public By ScanQrCodeBtn = By.XPath("(//span[@class='dx-button-text'])[1]");

        public By ManualEntryBtn = By.XPath("//span[contains(@class, 'dx-button-text') and text()='Ввести вручную']");
        public By CardNumberInput = By.CssSelector(".card-number-input");
        public By GoToProductsBtn = By.XPath("//span[@class='dx-button-text' and text()='Перейти к товарам']");
        public By ToCartBtn = By.XPath("//span[@class='dx-button-text' and text()='В корзину']");
        public By InCart = By.XPath("//a[text()='корзине']");
        public By BuyForPointBtn = By.XPath("//span[@class='dx-button-text' and text()='СПИСАТЬ БАЛЛЫ']");
        public By RemoveProductBtn = By.XPath("(//span[@class='dx-button-text' and text()='Убрать'])[2]");
        public By SearchBar = By.XPath("//div[@data-dx_placeholder='Поиск...' and @class='dx-placeholder']");
        public By ReturnBtn = By.XPath("//span[@class='dx-button-text' and text()='ВОЗВРАТ']");
        public By BackBtn = By.XPath("//span[@class='dx-button-text' and text()='НАЗАД']");

        //Assert
        private By PointCameraQrCodeTitle = By.CssSelector(".qr-scanner-text");
        private By ReturnTitle = By.CssSelector(".content-block.purchase-history-title");
        public KassaPage(IWebDriver driver) : base(driver) {}

        public void CheckThatQrCodeTitle(string text)
        {
            Assert.True(GetText(PointCameraQrCodeTitle).Contains(text));
        }
        public void CheckThatSearchBar()
        {
            Assert.True(IsElementPresent(SearchBar));
        }

        public void CheckReturnTitle(string text)
        {
            Assert.True(GetText(ReturnTitle).Contains(text));
        }

        public void EditKassaProfile(string Surname, string Name, string MiddleName, string OldPassword, string NewPassword, By element)
        {
            Clear(surnameInput);
            SendKeys(surnameInput, Surname);
            Clear(nameInput);
            Refresh();
            SendKeys(nameInput, Name);
            Clear(middleNameInput);
            SendKeys(middleNameInput, MiddleName);
            Clear(OldPasswordInput);
            SendKeys(OldPasswordInput, OldPassword);
            Clear(NewPasswordInput);
            SendKeys(NewPasswordInput, NewPassword);
            ChangePageZoom();
            Thread.Sleep(4000);
            Click(element);
            Thread.Sleep(4000);
        }

        public void ClickScanQrCodeButton() 
        {
            Click(ScanQrCodeBtn);
        }

        public void ClickManualEntryButton(string numESK, By element1, By element2, By element3) 
        {
            Click(ManualEntryBtn);
            SendKeys(CardNumberInput, numESK);
            Click(GoToProductsBtn);
            Click(element1);
            Click(element2);
            Click(element3);
        }

        public void ReturnSection(string numESK, By element)
        {
            Click(ManualEntryBtn);
            SendKeys(CardNumberInput, numESK);
            Click(GoToProductsBtn);
            Click(element);
        }
    }
}
