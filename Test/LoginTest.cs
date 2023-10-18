using CultureESK.Base;
using CultureESK.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CultureESK.Test
{
    [TestFixture]

    public class LoginTest : TestBase
    {
        [TestCase(TestName = "Вход с ролью Администратор")]
        public void LoggingWithAdminRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "12345678");

            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.09.2023 по 30.09.2023");
        }

        [TestCase(TestName = "Вход с ролью Управление")]
        public void LoggingWithManagmentRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");

            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.09.2023 по 30.09.2023");
        }

        [TestCase(TestName = "Вход с ролью Учреждение")]
        public void LoggingWithFacilityRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("uck", "12345678");

            mainPage.CheckThatAlertMsgContainsText("Отчет по посещениям гражданами учреждений культуры с использованием Единой социальной карты Свердловской области с 01.09.2023 по 30.09.2023");
        }

        [TestCase(TestName = "Вход с ролью Кассир")]
        public void LoggingWithKassaRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");

            mainPage.CheckThatCashierAlertMsgContainsText("Ввод номера ЕСК");
        }

        [TestCase(TestName = "Вход с невалидным логином")]
        public void LoggingWithInvalidLogin()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("ivalidLogin", "12345678");

            mainPage.CheckThatInvalidCredsAlert("Некорректный логин или пароль");
        }

        [TestCase(TestName = "Вход с невалидным паролем")]
        public void LoggingWithInvalidPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "123");

            mainPage.CheckThatInvalidCredsAlert("Некорректный логин или пароль");
        }

        [TestCase(TestName = "Вход с пробелом в логине и пароле")]
        public void LoggingWithSpaceInLoginAndPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword(" ", " ");

            mainPage.CheckThatInvalidCredsAlert("Некорректный логин или пароль");
        }

        [TestCase(TestName = "Вход без ввода данных")]
        public void LoggingWithoutDataEntry()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("", "");

            mainPage.CheckThatEmptyFieldAlert("Заполните все поля");
        }

    }
}