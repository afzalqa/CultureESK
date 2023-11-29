using OpenQA.Selenium;

namespace CultureESK.Pages
{
    public class AdminPage : PageBase
    {
        public AdminPage(IWebDriver driver) : base(driver) { }

        public By AddFacilityBtn = By.XPath("//span[@class='dx-button-text' and text()='Добавить учреждение']");
        private By FacilityNameString = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By FacilityShortNameString = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By AddressString = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        private By SaveNewFacilityBtn = By.XPath("//div[@class='dx-button-content']/span[@class='dx-button-text' and text()='Сохранить']");
        private By DropDownForChooseFacility = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        private By ChooseParentFacility = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='Отдых']");
        private By DropDownForChooseInvolved = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[2]");
        private By DropDownForChooseApproved = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[3]");
        public By InvolvedFacility = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='участвует']");
        public By NotInvolvedFacility = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='не участвует']");
        public By EditFacilityBtn = By.XPath("//i[@class='dx-icon dx-icon-edit']");
        public By DeleteFacilityOnTableBtn = By.XPath("//i[@class='dx-icon dx-icon-trash']");
        public By ConfirmDeleteFacilityBtn = By.XPath("//div[@class='dx-button-content' and contains(text(), 'Удалить')]");

        //Product
        private By AddProductBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Добавить')]");
        private By ProductNameString = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By ProductDescriptionString = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By ProductCount = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        private By ChooseTectUpk = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='Тестовое управление']");
        private By SaveNewProductBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Сохранить')]");
        public By AnyProductFromTable = By.XPath("(//span[@class='dx-checkbox-icon'])[2]");
        public By ApprovalProduct = By.XPath("//div[@class='dx-button-content']/span[@class='dx-button-text' and text()='Утвердить']");
        private By ApprovaledYesString = By.XPath("//td[@aria-describedby='dx-col-7' and @class='dx-cell-focus-disabled' and text()='Да']");
        private By CancelApproveBtn = By.XPath("//span[@class='dx-button-text' and text()='Отменить утверждение']");
        private By ApprovedProduct = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='Утверждено']");

        //profile
        public By AddNewProfileBtn = By.XPath("//span[@class=\"dx-button-text\" and text()=\"Добавить профиль\"]");
        private By LoginProfile = By.XPath("(//input[@class='dx-texteditor-input'])[1]");
        private By SurnameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[2]");
        private By NameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[3]");
        private By MiddleNameProfile = By.XPath("(//input[@class='dx-texteditor-input'])[4]");
        private By PasswordProfile = By.XPath("(//input[@class='dx-texteditor-input'])[5]");
        public By FacilityDropDownBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[1]");
        public By RoleDropDownBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[2]");
        private By SaveProfileBtn = By.XPath("//div[@class=\"dx-button-content\" and span[@class=\"dx-button-text\" and text()=\"Сохранить\"]]");
        public By AdminUpkString = By.XPath("//div[@class='dx-item-content dx-list-item-content' and text()='Администратор учреждения']");
        public By EditProfileBtn = By.XPath("//div[@class='dx-widget dx-button dx-button-mode-text dx-button-default dx-button-has-icon' and @aria-label='edit']");
        public By ProfileDeleteBtnOnTable = By.XPath("//i[@class='dx-icon dx-icon-trash']");
        public By ConfirmProfileDeleteBtn = By.XPath("//div[@class='dx-button-content' and contains(text(), 'Удалить')]");

        public void CheckThatApprovaledProduct(string text)
        {
            Assert.True(GetText(ApprovaledYesString).Contains(text));
        }

        public void AddNewFacility(string facilityName, string facilityShortName, string facilityAddress)
        {
            Click(AddFacilityBtn);
            SendKeys(FacilityNameString, facilityName);
            SendKeys(FacilityShortNameString, facilityShortName);
            Thread.Sleep(2000);
            Click(DropDownForChooseFacility);
            Thread.Sleep(2000);
            Click(ChooseParentFacility);
            SendKeys(AddressString, facilityAddress);
            Click(SaveNewFacilityBtn);
        }

        public void UpdateFacility(string facilityName, string facilityShortName, string facilityAddress, By element1, By element2)
        {
            Click(element1);
            SendKeys(FacilityNameString, facilityName);
            SendKeys(FacilityShortNameString, facilityShortName);
            Thread.Sleep(2000);
            Click(DropDownForChooseFacility);
            Thread.Sleep(2000);
            Click(ChooseParentFacility);
            SendKeys(AddressString, facilityAddress);
            Thread.Sleep(2000);
            Click(DropDownForChooseInvolved);
            Thread.Sleep(2000);
            Click(element2);
            Click(SaveNewFacilityBtn);
        }

        public void DeleteFacilityOrProfile(By element1, By element2)
        {
            Click(element1);
            Click(element2);
        }

        public void AddProductAsAdmin(string productName)
        {
            Click(AddProductBtn);
            SendKeys(ProductNameString, productName);
            Click(ProductCount);
            Click(DropDownForChooseInvolved);
            Click(ChooseTectUpk);
            Click(SaveNewProductBtn);
        }

        public void AddApprovedProductAsAdmin(string productName)
        {
            Click(AddProductBtn);
            SendKeys(ProductNameString, productName);
            Click(ProductCount);
            Click(DropDownForChooseInvolved);
            Click(ChooseTectUpk);
            Click(DropDownForChooseApproved);
            Click(ApprovedProduct);
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
            Click(FacilityDropDownBtn);
            Click(ChooseTectUpk);
            Click(RoleDropDownBtn);
            Thread.Sleep(2000);
            Click(element2);
            Click(SaveProfileBtn);
        }
    }
}
