using CultureESK.Base;
using CultureESK.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureESK.Test
{
    [TestFixture(TestName = "Доступные разделы для роли Кассир")]
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
    }
}
