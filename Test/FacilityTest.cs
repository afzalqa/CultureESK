using CultureESK.Base;
using CultureESK.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [TestCase(TestName = "Скачивание отчета")]
        public void DownloadReport()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            FacilityPage facilityPage = new FacilityPage(driver);

            sectionPage.LoginWithNameAndPassword("uck", "12345678");
            facilityPage.DownloadExelReport();
        }

    }
}
