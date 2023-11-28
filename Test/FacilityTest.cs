using CultureESK.Base;
using CultureESK.Pages;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Тесты для роли Учреждение")]
    public class FacilityTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Отчет")]
        public void SwitchToReportSection()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);

            sectionPage.LoginWithNameAndPassword("uck", "12345678");

            sectionPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.10.2023 по 31.10.2023");
        }

        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.ProductsAndServicesSection);

            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Переход в раздел Администрирование")]
        public void SwitchToAdministration()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);

            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Клик по кнопке Выход")]
        public void ClickExitButton()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.ExitButton);

            sectionPage.CheckThatAuthorizationTitle("Авторизация");
        }

        [TestCase(TestName = "Формирование отчета")]
        public void ReportGeneration() 
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("uck", "12345678");
            facilityPage.ReportGenerate();
            facilityPage.CheckThatFacilityNameTitle("Наименование учреждения");
        }

        [TestCase(TestName = "Скачивание отчета")]// доработать
        public void DownloadReport()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("uck", "12345678");
            facilityPage.DownloadExelReport();
        }

        [TestCase(TestName = "Добавление товара")]
        public void AddProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.AddProductAsFacility("Новый товар");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Удаление товара")] //доработать и придумать Assert
        public void RemoveProduct() 
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.RemoveProduct();
        }

        [TestCase(TestName = "Редактирование товара")]
        public void UpdateProduct() 
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.EditProductAsFacility("Редактируем товар", "Описание редактируемого товара");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Добавление профиля кассира")]
        public void AddNewKassirProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);
            facilityPage.AddNewKassirProfileAsFacility("atlogin", "atSurname", "atName", "atMiddlename", "asdf1234", facilityPage.AddNewProfileBtn, facilityPage.KassirRole);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Добавление профиля Администратора")]
        public void AddNewAdminProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);
            facilityPage.AddNewKassirProfileAsFacility("atlogin", "atSurname", "atName", "atMiddlename", "asdf1234", facilityPage.AddNewProfileBtn, facilityPage.AdminRole);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Редактиорвание профиля")]
        public void UpdateProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);
            facilityPage.AddNewKassirProfileAsFacility("updatelogin", "updateSurname", "updateName", "updateMiddlename", "asdf1234", facilityPage.EditProfileBtn, facilityPage.AdminRole);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Удаление профиля")]
        public void DeleteProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);
            facilityPage.DeleteProfile();
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }
    }
}
