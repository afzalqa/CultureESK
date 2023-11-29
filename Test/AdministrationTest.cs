using CultureESK.Base;
using CultureESK.Pages;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Тесты для роли Администратор")]
    public class AdministrationTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Отчет")]
        public void SwitchToReportSection()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginWithNameAndPassword("admin", "12345678");
            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.10.2023 по 31.10.2023");
        }

        [TestCase(TestName = "Переход в раздел Учреждения")]
        public void SwitchToFacilities()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("admin", "12345678", mainPage.ManagmentSection);
            mainPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("admin", "12345678", mainPage.ProductsAndServicesSection);
            mainPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Переход в раздел Администрирование")]
        public void SwitchToAdministration()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("admin", "12345678", mainPage.AdministrationSection);
            mainPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Клик по кнопке Выход")]
        public void ClickExitButton()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("admin", "12345678", mainPage.ExitButton);
            mainPage.CheckThatAuthorizationTitle("Авторизация");
        }

        [TestCase(TestName = "Формирование отчета")]
        public void ReportGeneration()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("admin", "12345678");
            facilityPage.ReportGenerate();
            facilityPage.CheckThatFacilityNameTitle("Наименование учреждения");
        }

        [TestCase(TestName = "Скачивание отчета")]// доработать
        public void DownloadReport()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("admin", "12345678");
            facilityPage.DownloadExelReport();
        }

        [TestCase(TestName = "Добавление нового учреждения")]
        public void AddNewFacilityAsAdmin()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ManagmentSection);
            adminPage.AddNewFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина");
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Добавление учреждения которое участвует в АЕ")]
        public void AddInvolvedFacilityAsAdmin()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ManagmentSection);
            adminPage.UpdateFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина", adminPage.AddFacilityBtn, adminPage.InvolvedFacility);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Редактирование учреждения")]
        public void EditFacilityAsAdmin()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ManagmentSection);
            adminPage.UpdateFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина", adminPage.EditFacilityBtn, adminPage.InvolvedFacility);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Удаление учреждения")]
        public void DeleteFacilityAsAdmin()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ManagmentSection);
            adminPage.DeleteFacilityOrProfile(adminPage.DeleteFacilityOnTableBtn, adminPage.ConfirmDeleteFacilityBtn);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Добавление товара")]
        public void AddProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ProductsAndServicesSection);
            adminPage.AddProductAsAdmin("Новый товар");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Добавление удтвержденного товара")]
        public void AddApprovedProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ProductsAndServicesSection);
            adminPage.AddApprovedProductAsAdmin("Новый товар");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Удаление товара")] //доработать и придумать Assert
        public void RemoveProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.RemoveProduct();
        }

        [TestCase(TestName = "Редактирование товара")]
        public void UpdateProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.EditProductAsFacility("Редактируем товар", "Описание редактируемого товара");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Удтверждение товара")]
        public void ApproveProductAsAdmin()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.ProductsAndServicesSection);
            adminPage.DeleteFacilityOrProfile(adminPage.AnyProductFromTable, adminPage.ApprovalProduct);
        }

        [TestCase(TestName = "Добавление профиля управления Культуры с ролью Администратор")]
        public void AddNewKassirProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.AdministrationSection);
            adminPage.AddNewKassirProfileAsFacility("atlogin", "atSurname", "atName", "atMiddlename", "asdf1234", adminPage.AddNewProfileBtn, adminPage.AdminUpkString);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Редактирование профиля управления Культуры с ролью Администратор")]
        public void EditProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            AdminPage adminPage = new AdminPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.AdministrationSection);
            adminPage.AddNewKassirProfileAsFacility("edit", "edit", "edit", "edit", "asdf1234", adminPage.EditProfileBtn, adminPage.AdminUpkString);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Удаление профиля")]
        public void DeleteProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("admin", "12345678", sectionPage.AdministrationSection);
            managmentPage.DeleteFacilityOrProfile(managmentPage.ProfileDeleteBtnOnTable, managmentPage.ConfirmProfileDeleteBtn);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }
    }
}
