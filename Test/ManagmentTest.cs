using CultureESK.Base;
using CultureESK.Pages;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Тесты для роли Управление")]
    public class ManagmentTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Отчет")]
        public void SwitchToReportSection()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");
            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.10.2023 по 31.10.2023");
        }

        [TestCase(TestName = "Переход в раздел Учреждения")]
        public void SwitchToFacilities()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.ManagmentSection);
            mainPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.ProductsAndServicesSection);
            mainPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Переход в раздел Администрирование")]
        public void SwitchToAdministration()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.AdministrationSection);
            mainPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Клик по кнопке Выход")]
        public void ClickExitButton()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.ExitButton);
            mainPage.CheckThatAuthorizationTitle("Авторизация");
        }

        [TestCase(TestName = "Формирование отчета")]
        public void ReportGeneration()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("upk", "12345678");
            facilityPage.ReportGenerate();
            facilityPage.CheckThatFacilityNameTitle("Наименование учреждения");
        }

        [TestCase(TestName = "Скачивание отчета")]// доработать
        public void DownloadReport()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("upk", "12345678");
            facilityPage.DownloadExelReport();
        }

        [TestCase(TestName = "Добавление нового учреждения")]
        public void AddNewFacilityAsManagment()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ManagmentSection);
            managmentPage.AddNewFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина");
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Добавление учреждения которое участвует в АЕ")]
        public void AddInvolvedFacilityAsManagment()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ManagmentSection);
            managmentPage.UpdateFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина", managmentPage.AddFacilityBtn, managmentPage.InvolvedFacility);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Редактирование учреждения")]
        public void EditFacilityAsManagment()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ManagmentSection);
            managmentPage.UpdateFacility("Новое учреждение", "Короткое нименование", "г Екатеринбург, пр-кт Ленина", managmentPage.EditFacilityBtn, managmentPage.InvolvedFacility);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Удаление учреждения")]
        public void DeleteFacilityAsManagment()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ManagmentSection);
            managmentPage.DeleteFacilityOrProfile(managmentPage.DeleteFacilityOnTableBtn, managmentPage.ConfirmDeleteFacilityBtn);
            sectionPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Добавление товара")]
        public void AddProduct()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.AddProductAsFacility("Новый товар");
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

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.ProductsAndServicesSection);
            facilityPage.EditProductAsFacility("Редактируем товар", "Описание редактируемого товара");
            sectionPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Добавление профиля учреждения Культуры")]
        public void AddNewKassirProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.AdministrationSection);
            managmentPage.AddNewKassirProfileAsFacility("atlogin", "atSurname", "atName", "atMiddlename", "asdf1234", managmentPage.AddNewProfileBtn, managmentPage.ManagmentCultureString);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Редактиорвание профиля")]
        public void UpdateProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("upk", "12345678", sectionPage.AdministrationSection);
            managmentPage.AddNewKassirProfileAsFacility("atlogin", "atSurname", "atName", "atMiddlename", "asdf1234", managmentPage.EditProfileBtn, managmentPage.ManagmentCultureString);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Удаление профиля")]
        public void DeleteProfileAsFacility()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            ManagmentPage managmentPage = new ManagmentPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("uck", "12345678", sectionPage.AdministrationSection);
            managmentPage.DeleteFacilityOrProfile(managmentPage.ProfileDeleteBtnOnTable, managmentPage.ConfirmProfileDeleteBtn);
            sectionPage.CheckThatAdministrationTitle("Администрирование");
        }
    }
}
