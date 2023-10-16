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
        [Test]
        public void LoginWithAdminRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("admin", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }
        [Test]
        public void LoginWithManagmentRole()
        {
            MainPage mainPage = new MainPage(driver);

            mainPage.LoginWithNameAndPassword("upk", "12345678");

            mainPage.CheckThatAlertMsgContainsText("����� �� ���������� ���������� ���������� �������� � �������������� ������ ���������� ����� ������������ ������� � 01.09.2023 �� 30.09.2023");
        }

    }
}