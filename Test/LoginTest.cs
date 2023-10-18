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
        [TestCase(TestName = "���� � ����� �������������")]
        public void LoggingWithAdminRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [TestCase(TestName = "���� � ����� ����������")]
        public void LoggingWithManagmentRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [TestCase(TestName = "���� � ����� ����������")]
        public void LoggingWithFacilityRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("uck", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

        [TestCase(TestName = "���� � ����� ������")]
        public void LoggingWithKassaRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("kassa", "12345678");

            mainPage.CheckThatCashierAlertMsgContainsText("���� ������ ���");
        }

        [TestCase(TestName = "���� � ���������� �������")]
        public void LoggingWithInvalidLogin()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("ivalidLogin", "12345678");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [TestCase(TestName = "���� � ���������� �������")]
        public void LoggingWithInvalidPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "123");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [TestCase(TestName = "���� � �������� � ������ � ������")]
        public void LoggingWithSpaceInLoginAndPassword()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword(" ", " ");

            mainPage.CheckThatInvalidCredsAlert("������������ ����� ��� ������");
        }

        [TestCase(TestName = "���� ��� ����� ������")]
        public void LoggingWithoutDataEntry()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("", "");

            mainPage.CheckThatEmptyFieldAlert("��������� ��� ����");
        }

    }
}