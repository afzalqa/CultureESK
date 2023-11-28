using OpenQA.Selenium;

namespace CultureESK.Pages
{
    public class FacilityPage : PageBase
    {
        public FacilityPage(IWebDriver driver) : base(driver) { }

        //Report Page Buttons
        private By StartDateBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[1]");
        private By EndDateBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[2]");
        private By CalendarMonthTitle = By.XPath("//span[@class='dx-button-text' and text()='октябрь 2023 г.']");
        private By January = By.XPath("//span[text()='янв.']");
        private By FirstDayOfJanuary = By.XPath("//span[text()='1']");
        private By ReportBtn = By.XPath("//*[@aria-label='Отчет']");
        private By DownloadExelBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Скачать Excel')]");

        private By AddProductBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Добавить')]");
        private By ProductNameString = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By ProductDescriptionString = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By ProductCount = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        private By SaveNewProductBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Сохранить')]");

        private By AnyProductFromTable = By.XPath("(//span[@class='dx-checkbox-icon'])[2]");
        private By DeleteProductBtn = By.XPath("//span[@class=\"dx-button-text\" and text()=\"Удалить\"]");

        public By AddNewProfileBtn = By.XPath("//span[@class=\"dx-button-text\" and text()=\"Добавить профиль\"]");
        private By LoginProfile = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By SurnameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By NameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By MiddleNameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By PasswordProfile = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        private By RoleDropDownBtn = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        public By KassirRole = By.XPath("//div[@class=\"dx-item-content dx-list-item-content\" and text()=\"Кассир\"]");
        public By AdminRole = By.XPath("//div[@class=\"dx-item-content dx-list-item-content\" and text()=\"Администратор учреждения\"]");
        private By SaveProfileBtn = By.XPath("//div[@class=\"dx-button-content\" and span[@class=\"dx-button-text\" and text()=\"Сохранить\"]]");
        public By EditProfileBtn = By.XPath("//div[@class='dx-widget dx-button dx-button-mode-text dx-button-default dx-button-has-icon' and @aria-label='edit']");
        private By ProfileDeleteBtnOnTable = By.XPath("//i[@class='dx-icon dx-icon-trash']");
        private By ConfirmProfileDeleteBtn = By.XPath("//div[@class='dx-button-content' and contains(text(), 'Удалить')]");

        //Assert
        private By FacilityNameTitle = By.XPath("//th[text()='Наименование учреждения']");
        private By ProductNamaTitle = By.XPath("//td[@class=\"dx-cell-focus-disabled\" and text()=\"Новый товар\"]");
        public By EditProductBtn = By.XPath("//i[@class=\"dx-icon dx-icon-edit\"]");
        public void CheckThatFacilityNameTitle(string text)
        {
            Assert.True(GetText(FacilityNameTitle).Contains(text));
        }

        public void CheckThatNewProduct(string text)
        {
            Assert.True(GetText(ProductNamaTitle).Contains(text));
        }

        public void ReportGenerate()
        {
            Click(StartDateBtn);
            Click(CalendarMonthTitle);
            Click(January);
            Click(FirstDayOfJanuary);
            Click(ReportBtn);
        }

        public void DownloadExelReport()
        {
            Click(StartDateBtn);
            Click(CalendarMonthTitle);
            Click(January);
            Click(FirstDayOfJanuary);
            Click(ReportBtn);
            Click(DownloadExelBtn);
        }

        public void AddProductAsFacility(string productName)
        {
            Click(AddProductBtn);
            SendKeys(ProductNameString, productName);
            Click(ProductCount);
            Click(SaveNewProductBtn);
        }

        public void RemoveProduct()
        {
            Click(AnyProductFromTable);
            Click(DeleteProductBtn);
        }

        public void EditProductAsFacility(string productName, string description)
        {
            Click(EditProductBtn);
            Clear(ProductNameString);
            SendKeys(ProductNameString, productName);
            Clear(ProductDescriptionString);
            SendKeys(ProductDescriptionString, description);
            Click(ProductCount);
            Click(SaveNewProductBtn);
        }

        public void AddNewKassirProfileAsFacility(string login, string surname, string name, string middleName, string password, By element1, By element2)
        {
            Click(element1);
            SendKeys(LoginProfile, login);
            SendKeys(SurnameProfile, surname);
            SendKeys(NameProfile, name);
            SendKeys(MiddleNameProfile, middleName);
            SendKeys(PasswordProfile, password);
            Thread.Sleep(2000);
            Click(RoleDropDownBtn);
            Thread.Sleep(2000);
            Click(element2);
            Click(SaveProfileBtn);
        }

        public void DeleteProfile()
        {
            Click(ProfileDeleteBtnOnTable);
            Click(ConfirmProfileDeleteBtn);
        }
    }
}
