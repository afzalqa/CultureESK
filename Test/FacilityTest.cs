using CultureESK.Base;
using CultureESK.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Доступные разделы для роли Учреждение")]
    public class FacilityTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Отчет")]
        public void SwitchToReportSection()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginWithNameAndPassword("uck", "12345678");

            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.09.2023 по 30.09.2023");
        }

        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("uck", "12345678", mainPage.ProductsAndServicesSection);

            mainPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }

        [TestCase(TestName = "Переход в раздел Администрирование")]
        public void SwitchToAdministration()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("uck", "12345678", mainPage.AdministrationSection);

            mainPage.CheckThatAdministrationTitle("Администрирование");
        }

        [TestCase(TestName = "Клик по кнопке Выход")]
        public void ClickExitButton()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("uck", "12345678", mainPage.ExitButton);

            mainPage.CheckThatAuthorizationTitle("Авторизация");
        }
    }
}
