using CultureESK.Base;
using CultureESK.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Тесты роли Кассир")]
    public class KassaTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");

            mainPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
        }

        [TestCase(TestName = "Переход в раздел Профиль")]
        public void SwitchToProfileSection()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("kassa", "12345678", mainPage.ProfileButton);

            mainPage.CheckThatEditProfileTitle("Редактирование профиля");
        }

        [TestCase(TestName = "Клик по кнопке Выход")]
        public void ClickExitButton()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);

            mainPage.LoginAsManagmentAndSwitch("kassa", "12345678", mainPage.ExitButton);

            mainPage.CheckThatAuthorizationTitle("Авторизация");
        }

        [TestCase(TestName = "Редактирование профиля кассира")]
        public void EditKassaProfile()
        {
            SectionsHelper mainPage = new SectionsHelper(driver);
            KassaPage kassaPage = new KassaPage(driver);

            mainPage.LoginAsManagmentAndSwitch("kassa", "12345678", mainPage.ProfileButton);
            kassaPage.EditKassaProfile("Иванов", "Иван", "Иванович", "12345678", "12345678", kassaPage.SaveButton);
            mainPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
        }

        [TestCase(TestName = "Отмена редактирвоания профиля кассира")]
        public void CancelEditingKassaProfile() 
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            KassaPage kassaPage = new KassaPage(driver);

            sectionPage.LoginAsManagmentAndSwitch("kassa", "12345678", sectionPage.ProfileButton);
            kassaPage.EditKassaProfile("Иванов", "Иван", "Иванович", "12345678", "12345678", kassaPage.CancelButton);
            sectionPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
        }

        [TestCase(TestName = "Клик по кнопке Сканировать QR-код")]
        public void ClickScanQrCodeBuuton()
        {
            MainPage mainPage = new MainPage(driver);
            KassaPage kassaPage = new KassaPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");
            Thread.Sleep(4000);
            kassaPage.ClickScanQrCodeButton();
            kassaPage.CheckThatQrCodeTitle("Наведите камеру на QR-код");
        }
    }
}
