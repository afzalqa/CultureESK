using OpenQA.Selenium;

namespace CultureESK.Pages
{
    public class ManagmentPage : PageBase
    {
        public ManagmentPage(IWebDriver driver) : base(driver) { }

        public By AddFacilityBtn = By.XPath("//span[@class='dx-button-text' and text()='Добавить учреждение']");
        private By FacilityNameString = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By FacilityShortNameString = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By AddressString = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By SaveNewFacilityBtn = By.XPath("//div[@class='dx-button-content']/span[@class='dx-button-text' and text()='Сохранить']");
        public By EditFacilityBtn = By.XPath("//i[@class='dx-icon dx-icon-edit']");
        private By DropDownBtn = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        public By InvolvedFacility = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='участвует']");
        public By NotInvolvedFacility = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='не участвует']");
        public By DeleteFacilityOnTableBtn = By.XPath("//i[@class='dx-icon dx-icon-trash']");
        public By ConfirmDeleteFacilityBtn = By.XPath("//div[@class='dx-button-content' and contains(text(), 'Удалить')]");

        public By AddNewProfileBtn = By.XPath("//span[@class=\"dx-button-text\" and text()=\"Добавить профиль\"]");
        private By LoginProfile = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By SurnameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By NameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By MiddleNameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By PasswordProfile = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        public By RoleDropDownBtn = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        private By SaveProfileBtn = By.XPath("//div[@class=\"dx-button-content\" and span[@class=\"dx-button-text\" and text()=\"Сохранить\"]]");
        public By ManagmentCultureString = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='Управление культуры']");
        public By EditProfileBtn = By.XPath("//div[@class='dx-widget dx-button dx-button-mode-text dx-button-default dx-button-has-icon' and @aria-label='edit']");
        public By ProfileDeleteBtnOnTable = By.XPath("//i[@class='dx-icon dx-icon-trash']");
        public By ConfirmProfileDeleteBtn = By.XPath("//div[@class='dx-button-content' and contains(text(), 'Удалить')]");


        public void AddNewFacility(string facilityName, string facilityShortName, string facilityAddress)
        {
            Click(AddFacilityBtn);
            SendKeys(FacilityNameString, facilityName);
            SendKeys(FacilityShortNameString, facilityShortName);
            SendKeys(AddressString, facilityAddress);
            Click(SaveNewFacilityBtn);
        }

        public void UpdateFacility(string facilityName, string facilityShortName, string facilityAddress, By element1, By element2)
        {
            Click(element1);
            SendKeys(FacilityNameString, facilityName);
            SendKeys(FacilityShortNameString, facilityShortName);
            SendKeys(AddressString, facilityAddress);
            Thread.Sleep(2000);
            Click(DropDownBtn);
            Thread.Sleep(2000);
            Click(element2);
            Click(SaveNewFacilityBtn);
        }

        public void DeleteFacilityOrProfile(By element1, By element2) 
        {
            Click(element1);
            Click(element2);
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
    }
}
