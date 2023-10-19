using CultureESK.Base;
using CultureESK.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Test
{
    [TestFixture]
    public class ManagmentTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Отчет")]
        public void SwitchToReportSection()
        {
            ManagmentPageHelper mainPage = new ManagmentPageHelper(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");

            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.09.2023 по 30.09.2023");
        }

        [TestCase(TestName = "Переход в раздел Учреждения")]
        public void SwitchToFacilities()
        {
            ManagmentPageHelper mainPage = new ManagmentPageHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.ManagmentBtn);

            mainPage.CheckThatFacilityTitle("Учреждения");
        }

        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            ManagmentPageHelper mainPage = new ManagmentPageHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("upk", "12345678", mainPage.ProductsAndServicesBtn);

            mainPage.CheckThatProductsAndServicesTitle("Товары и услуги");
        }
    }
}
