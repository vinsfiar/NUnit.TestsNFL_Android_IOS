using ExportedFromAppiumStudioFirstTest.Resources;
using Newtonsoft.Json.Linq;
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
using System.Drawing;

namespace NUnit.TestsNFL_Android_IOS
{
    [TestFixture]
    [Ignore("Works Correctly")]
    public class NoLoggedInTests : BaseTestsAndroid
    {
        [Test]
        //[Ignore("Works Correctly")]
        public void LogOut()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

           driver.ClickOn(SignInOutPage.LogOut);

           wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [Test]
        //[Ignore("Works Correctly")]
        public void NoLoggedInUsersShouldBeAbleToFindAllTeamsOnTeamPage()
        {        
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.Teams);
            AdditionalMethods.FindAllElementsIn(driver, XPathProviderAndroid.TeamsXpath);          
        }
        

        [Test]
        [Ignore("Works Correctly")]
        // In this case swipeWhileNotFound is working correctly, maybe because is looking for an element, not a button!
        public void NoLoggedInUsersShouldBeAbleToFindNFLPrograms()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLPrograms);
            AdditionalMethods.FindAllElementsIn(driver, NFLPrograms.Programs);
        }

        [Test]
        [Ignore("Works Correctly")]
        public void NoLoggedInUsersShouldBeAbleToFindNFLOriginals()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLOriginals);
            AdditionalMethods.FindAllElementsIn(driver, NFLOriginals.ProgramList);

        }

        [Test]
        [Ignore("Works Correctly")]
        public void SettingFavoriteTeamShouldNotBePossibleWhenLoggedOut()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.SwipeWhileNotClickable(Hamburger.Settings, 5, Offset.Half);
            driver.ClickOn(SettingsPage.FavoriteTeamButton);

            bool displayed = driver.IsElementDisplayed(SettingsPage.NotificationMessage);
            Assert.IsTrue(displayed);
        }


        [Test]
        [Ignore("Works Correctly")]
        // In this case swipeWhileNotFound dos not work correctly, maybe because it is looking for a button
        public void NoLoggedInUsersShouldBeAbleToSubscribeWithFreeTrial()
        {
            driver.ClickOn(BasePage.SubscribeButton);

            for (int i = 0; i < 3; i++)
                driver.ExecuteScript("seetest:client.swipe(\"Down\", 10, 500)");

            driver.ClickOn(SubscribePage.FreeTrial);
            Assert.IsTrue(driver.IsElementDisplayed(SubscribePage.SignUp));
        }

        [Test]
        [Ignore("Works Correctly")]
        public void NologgedInUserShouldBeAbleButAnnualSubscription()
        {
            driver.ClickOn(BasePage.SubscribeButton);
            driver.ExecuteScript("seetest:client.swipe(\"Down\", 10, 500)");

            driver.ClickOn(SubscribePage.BuyNow);
            Assert.IsTrue(driver.IsElementDisplayed(SubscribePage.SignUp));
        }
        
   
        [Test]
        [Ignore("Works Correctly")]
        public void NoLoggedInUserSholdBeAbleToSwitchSettings_ON_And_OFF()
        {
            AppiumWebElement[] elem = new AppiumWebElement[4];
            string[] text_before = new string[4];
            string[] text_after = new string[4];

            driver.ClickOn(Hamburger.MenuButton);
            driver.SwipeWhileNotClickable(Hamburger.Settings, 5, Offset.Half);

            elem[0] = driver.FindElementByXPath(SettingsPage.NotificationButton);
            elem[1] = driver.FindElementByXPath(SettingsPage.SaveToSDButton);
            elem[2] = driver.FindElementByXPath(SettingsPage.ScoresButton);
            elem[3] = driver.FindElementByXPath(SettingsPage.DownloadsButton);

            for(int i = 0; i < 4; i++)
            {
                text_before[i] = elem[i].GetAttribute("text");
                elem[i].Click();
                text_after[i] = elem[i].GetAttribute("text");

                Assert.AreNotEqual(text_before[i], text_after[i]);
            }
        }
    }
}
