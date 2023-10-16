using CultureESK.Base;
using CultureESK.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CultureESK.Test
{
    [TestFixture]

    public class LoginTest : TestBase
    {
        [Test(Description = "���� � ����� �������������")]
        public void LoggingWithAdminRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [Test(Description = "���� � ����� ����������")]
        public void LoggingWithManagmentRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [Test(Description = "���� � ����� ����������")]
        public void LoggingWithFacilityRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("uck", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [Test(Description = "���� � ����� ������")]
        public void LoggingWithKassaRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");

            mainPage.CheckThatCashierAlertMsgContainsText("���� ������ ���");
        }

        [Test(Description = "���� � ���������� �������")]
        public void LoggingWithInvalidLogin()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("ivalidLogin", "12345678");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [Test(Description = "���� � ���������� �������")]
        public void LoggingWithInvalidPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "123");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [Test(Description = "���� � �������� � ������ � ������")]
        public void LoggingWithSpaceInLoginAndPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword(" ", " ");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [Test(Description = "���� ��� ����� ������")]
        public void LoggingWithoutDataEntry()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("", "");

            mainPage.CheckThatEmptyFieldAlert("��������� ��� ����");
        }

    }
}