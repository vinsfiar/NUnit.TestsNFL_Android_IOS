using ExportedFromAppiumStudioFirstTest.Resources;
using NUnit.Framework;
using NUnit.TestsNFL_Android_IOS.Android_Pages;
using NUnit.TestsNFL_Android_IOS.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    //[TestFixture]
    //[Ignore("Work Correctly.")]
    class AllTests : BaseTestsAndroid
    {
        //[TestCase("enzofiar", "G1m2P1ss"), Order(2)]
        //[Ignore("Work Correctly.")]
        public void UsersShouldBeAbleToLogIn(string userName, string password)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            driver.FindElement(By.XPath(SignInOutPage.EmailUsernameField)).SendKeys(userName);
            driver.FindElement(By.XPath(SignInOutPage.PasswordField)).SendKeys(password);
            driver.ClickOn(SignInOutPage.LogIn);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        //[Test, Order(1)]
        public void NoLoggedInUsersShouldBeAbleToFindNFLOriginals()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLOriginals);
            AdditionalMethods.FindAllElementsIn(driver, NFLOriginals.ProgramList);

        }

        //[Test, Order(3)]
        //[Ignore("Work Correctly.")]
        public void AnyUserShouldBeAbleToLogOut()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            driver.ClickOn(SignInOutPage.LogOut);

            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }
    }
}
