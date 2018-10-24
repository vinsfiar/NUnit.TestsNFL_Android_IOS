using ExportedFromAppiumStudioFirstTest.Resources;
using NUnit.Framework;
using NUnit.TestsNFL_Android_IOS.Android_Pages;
using NUnit.TestsNFL_Android_IOS.Android_Tests;
using NUnit.TestsNFL_Android_IOS.DataProvider;
using NUnit.TestsNFL_Android_IOS.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS
{
    [TestFixture]
    class LoggedInTests : BaseTestsAndroid
    {
        [TestCase("enzofiar", "G1m2P1ss")]
        [TestCase("vinsfiar", "V3nc2nz4")]
        [Ignore("Works Correctly")]
        public void AnyUserProvidingValidCredentialsShoulBeAbleToLogInAndOut(string userName, string password)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLNetwork);
            driver.ClickOn(SignInOutPage.LogIn);

            driver.FindElement(By.XPath(SignInOutPage.EmailUsernameField)).SendKeys(userName);
            driver.FindElement(By.XPath(SignInOutPage.PasswordField)).SendKeys(password);

            driver.ClickOn(SignInOutPage.LogIn);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            driver.ClickOn(SignInOutPage.LogOut);
        }

        [TestCase("Jaguars")]
        [TestCase("Broncos")]
        [TestCase("Bills")]
        [TestCase("Browns")]
        [Ignore("Works Correctly")]
        public void AnyLoggedInUserShouldBeAbleToSetTheFofavoriteTeam(string name)
        {
            string check = "//*[@text='TEAM' and @id='menu_item_title']";
            string team = "//*[@text='" + name + "']";
            check = "//*[contains(text(),'" + name.ToUpper() + "')]";

            driver.ClickOn(Hamburger.MenuButton);
            driver.SwipeWhileNotClickable(Hamburger.Settings, 5, Offset.Half);

            driver.ClickOn(SettingsPage.FavoriteTeamButton);
            driver.ClickOn(team);
            driver.ClickOn(SettingsPage.ApplyButton);
            driver.ClickOn(SettingsPage.OKButton);

            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.MenuButton);

            string check_team = driver.FindElement(By.XPath(check)).GetAttribute("text");

            Assert.AreEqual(name.ToUpper(), check_team);
        }       
    }
}

