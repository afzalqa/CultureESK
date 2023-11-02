using CultureESK.Base;
using CultureESK.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Тесты роли Кассир")]
    public class KassaTest : TestBase
    {
        [TestCase(TestName = "Переход в раздел Товары и услуги")]
        public void SwitchToProductsAndServices()
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);

            sectionPage.LoginWithNameAndPassword("kassa", "12345678");

            sectionPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
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
            kassaPage.EditKassaProfile("Иванов", "Иван", "Иванович", "12345678", "12345678", kassaPage.SaveBtn);      
            mainPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
        }

        [TestCase(TestName = "Отмена редактирвоания профиля кассира")]
        public void CancelEditingKassaProfile() 
        {
            SectionsHelper sectionPage = new SectionsHelper(driver);
            KassaPage kassaPage = new KassaPage(driver);
            sectionPage.LoginAsManagmentAndSwitch("kassa", "12345678", sectionPage.ProfileButton);
            kassaPage.EditKassaProfile("Иванов", "Иван", "Иванович", "12345678", "12345678", kassaPage.CancelBtn);
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

        [TestCase(TestName = "Ввод номера карты вручную и покупка товара")]
        public void EnteringESKnumAndBuyProduct()
        {
            MainPage mainPage = new MainPage(driver);
            KassaPage kassaPage = new KassaPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");
            kassaPage.ClickManualEntryButton("012000254165", kassaPage.ToCartBtn, kassaPage.InCart, kassaPage.BuyForPointBtn);
        }

        [TestCase(TestName = "Отмена покупки товара")]
        public void ProductCancellation()
        {
            MainPage mainPage = new MainPage(driver);
            KassaPage kassaPage = new KassaPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");
            kassaPage.ClickManualEntryButton("012000254165", kassaPage.ToCartBtn, kassaPage.InCart, kassaPage.RemoveProductBtn);
            kassaPage.CheckThatSearchBar();
        }

        [TestCase(TestName = "Переход в раздел Возврат")]
        public void SwitchToReturnSection()
        {
            MainPage mainPage = new MainPage(driver);
            KassaPage kassaPage = new KassaPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");
            kassaPage.ReturnSection("012000254165", kassaPage.ReturnBtn);
            kassaPage.CheckReturnTitle("Возврат");

        }

        [TestCase(TestName = "Переход в раздел товара и переход назад")]
        public void GoToProductSectionAndGoBack()
        {
            MainPage mainPage = new MainPage(driver);
            KassaPage kassaPage = new KassaPage(driver);
            SectionsHelper sectionPage = new SectionsHelper(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");
            kassaPage.ReturnSection("012000254165", kassaPage.BackBtn);
            sectionPage.CheckThatEnteringESKNumberTitle("Ввод номера ЕСК");
        }
    }
}
