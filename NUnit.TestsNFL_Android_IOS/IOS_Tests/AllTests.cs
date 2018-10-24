using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.TestsNFL_Android_IOS.IOS_Pages;
using System.Threading;
using NUnit.TestsNFL_Android_IOS.Resources;

using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium;
using ExportedFromAppiumStudioFirstTest.Resources;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;

namespace NUnit.TestsNFL_Android_IOS.IOS_Tests
{
    [TestFixture]
    class AllTests : BaseTestsIOS
    {

        [TestCase("enzofiar", "G1m2P1ss"), Order(1)]
        [Ignore("Works Correctly.")]
        public void UsersShouldBeAbleToLogIn(string userName, string password)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            if(AdditionalMethods.IsElementDisplayed(driver, SignInOutPage.LogIn))
            {
                driver.FindElement(By.XPath(SignInOutPage.EmailUsernameField)).SendKeys(userName);
                driver.FindElement(By.XPath(SignInOutPage.PasswordField)).SendKeys(password);
                driver.ClickOn(SignInOutPage.LogIn);
            }
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton)));
            bool present = AdditionalMethods.IsElementDisplayed(driver, Hamburger.MenuButton);
            Assert.IsTrue(present);
        }


        [TestCase("((//*[@class='UIACollectionView']/*/*/*[@class='UIAView' and ./parent::*[@class='UIAView' and ./parent::*[@class='UIAView']]])[1]/*[@class='UIAView'])[2]"), Order(2)]
        [Ignore("Works Correctly.")]
        public void UsersShouldNotBeAbleToAccessContentsInNFLPrograms(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLPrograms);

            string good_morning = NFLPrograms.GoodMorningFootball;

            for (int i = 0; i < 3; i++)
                driver.ExecuteScript("seetest:client.swipe(\"Down\", 30, 500)");

            driver.ClickOn(good_morning);
            driver.ClickOn(play);

            Thread.Sleep(8000);
        }

        [TestCase("((//*[@class='UIACollectionView']/*/*/*[@class='UIAView' and ./parent::*[@class='UIAView' and ./parent::*[@class='UIAView']]])[2]/*[@class='UIAView'])[2]"), Order(3)]
        [Ignore("Works Correctly.")]
        public void LoggedInUserShouldNotBeAbleToAccessContentsInNFLOriginals(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLOriginals);

            string hard_knoks = NFLOriginals.HardKnoks;

            for (int i = 0; i < 3; i++)
                driver.ExecuteScript("seetest:client.swipe(\"Down\", 30, 500)");

            driver.ClickOn(hard_knoks);
            driver.ClickOn(play);

            Thread.Sleep(8000);
        }

        [TestCase("//*[@text='featured_play_icon' and (./preceding-sibling::* | ./following-sibling::*)[@text='WEEK 6']]"), Order(4)]
        [Ignore("Works Correctly.")]
        public void UserShouldNotBeAbleToAccessContentsInNFLRedzone(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLRedZone);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton)));

            string script = "seetest:client.swipeWhileNotFound(\"Down\", 30, 2000, \"NATIVE\", \"xpath=ELEM\", 0, 1000, 5, true)";
            script = script.Replace("ELEM", play);

            driver.ExecuteScript(script);

            Thread.Sleep(8000);
        }

        [Test, Order(5)]
        [Ignore("Works Correctly.")]
        public void UsersShoulBeAbleToCheckSubscriptionDetails()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);
            //driver.ExecuteScript("seetest:client.swipe(\"Down\", 0, 500)");

            wait.Until(ExpectedConditions.ElementExists(By.XPath(SignInOutPage.YourSub)));

            string your_sub = driver.FindElement(By.XPath(SignInOutPage.YourSub)).GetAttribute("text");
            string sub = driver.FindElement(By.XPath(SignInOutPage.Sub)).GetAttribute("text");
            string bill = driver.FindElement(By.XPath(SignInOutPage.Bill)).GetAttribute("text");
            string access = driver.FindElement(By.XPath(SignInOutPage.Access)).GetAttribute("text");

            Assert.AreEqual("Your subscription", your_sub);
            Assert.AreEqual("Subscription", sub);
            Assert.AreEqual("Billed date", bill);
            Assert.AreEqual("Access until", access);
        }

        [Test, Order(6)]
        [Ignore("Works Correctly.")]
        public void UsersShoulBeAbleToCheckAccountDetails()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);
            //driver.ExecuteScript("seetest:client.swipe(\"Down\", 0, 500)");

            wait.Until(ExpectedConditions.ElementExists(By.XPath(SignInOutPage.YourProfile)));

            string your_profile = driver.FindElement(By.XPath(SignInOutPage.YourProfile)).GetAttribute("text");
            string user = driver.FindElement(By.XPath(SignInOutPage.User)).GetAttribute("text");
            string email = driver.FindElement(By.XPath(SignInOutPage.Email)).GetAttribute("text");
            string pass = driver.FindElement(By.XPath(SignInOutPage.Password)).GetAttribute("text");

            Assert.AreEqual("Your profile", your_profile);
            Assert.AreEqual("Username", user);
            Assert.AreEqual("Email", email);
            Assert.AreEqual("Password", pass);
        }

        [Test, Order(7)]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessLiveContents()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLNetwork);
            driver.ClickOn(BasePage.LiveButton);
            
            Thread.Sleep(8000);
        }


        [TestCase("//*[@text='NFL PROGRAMS']"), Order(8)]
        [TestCase("//*[@text='NFL ORIGINALS']")]
        [TestCase("//*[@text='NFL REDZONE']")]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromEveryPage(string page)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(page);
            driver.ClickOn(BasePage.WatchNowButton);
           
            Thread.Sleep(8000);
        }

        [TestCase("//*[@text='FULL GAME REPLAY']", "//*[@text='JAGUARS' and ./parent::*[./parent::*[./parent::*[./parent::*[@class='UIACollectionView']]]] and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]"), Order(9)]
        [TestCase("//*[@text='GAME IN 40']", "//*[@text='JAGUARS' and ./parent::*[./parent::*[./parent::*[./parent::*[@class='UIACollectionView']]]] and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [TestCase("//*[@text='HIGHLIGHTS']", "//*[@text='JAGUARS' and ./parent::*[./parent::*[./parent::*[./parent::*[@class='UIACollectionView']]]] and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [TestCase("//*[@text='COACHES FILM']", "//*[@text='JAGUARS' and ./parent::*[./parent::*[./parent::*[./parent::*[@class='UIACollectionView']]]] and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromTeamPage(string mode, string team)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(team);           
            driver.ClickOn(BasePage.WatchNowButton);
            driver.ClickOn(mode);

            Thread.Sleep(8000);
        }

        [TestCase("//*[@text='FULL GAME REPLAY']", "//*[@text='GAMES' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]"), Order(10)]
        [TestCase("//*[@text='GAME IN 40']", "//*[@text='GAMES' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [TestCase("//*[@text='HIGHLIGHTS']", "//*[@text='GAMES' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [TestCase("//*[@text='COACHES FILM']", "//*[@text='GAMES' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]")]
        [Ignore("Watch-Now Not Always Present.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromGamesPage(string mode, string games)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(games);
            driver.ClickOn(BasePage.WatchNowButton);
            driver.ClickOn(mode);

            Thread.Sleep(8000);
        }

        [TestCase("//*[@text='FULL GAME REPLAY']", "//*[@text='JAGUARS']"), Order(11)]
        [TestCase("//*[@text='GAME IN 40']", "//*[@text='JAGUARS']")]
        [TestCase("//*[@text='HIGHLIGHTS']", "//*[@text='JAGUARS']")]
        [TestCase("//*[@text='COACHES FILM']", "//*[@text='JAGUARS']")]
        [Ignore("Does not work: Swipe Action does not perform as expected. Swipe works in Appium Studio!")]
        public void LoggedInUsersShouldBeAbleToDownloadAndRemoveVideos(string mode, string team)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);

            driver.ClickOn(team);
            driver.ClickOn(BasePage.WatchNowButton);
            driver.ClickOn(BasePage.DownloadButton);
            driver.ClickOn(mode);
            driver.ClickOn("//*[contains(text(),'LOW')]");          

            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
            Thread.Sleep(3000);
            
            //Swipe Action works well in Appium Studio but not here!
            driver.Swipe(600, 300, 0, 300, 1000);
            driver.ClickOn("xpath=//*[@text='download remove']");
           
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
        }

        [TestCase("//*[@text='GAME IN 40']", "//*[@text='JAGUARS']", 1), Order(12)]
        //[TestCase("//*[@text='FULL GAME REPLAY']", "//*[@text='JAGUARS']", 1)]
        //[TestCase("//*[@text='HIGHLIGHTS']", "//*[@text='JAGUARS']", 1)]
        //[TestCase("//*[@text='COACHES FILM']", "//*[@text='JAGUARS']", 1)]
        [Ignore("Works properly with no videos in My Download.")]
        public void LoggedInUsersShouldBeAbleToDownloadVideosCompletely(string mode, string team, double minutes)
        {
            string completed = "//*[contains(text(),'COMPLETED')]";
            string downloading = "//*[@text='DOWNLOADING']";
            bool finished = false;

            double millisec = TimeSpan.FromMinutes(minutes).TotalMilliseconds;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);

            driver.ClickOn(team);
            driver.ClickOn(BasePage.WatchNowButton);
            driver.ClickOn(BasePage.DownloadButton);
            driver.ClickOn(mode);
            driver.ClickOn("//*[contains(text(),'LOW')]");

            wait.Until(ExpectedConditions.ElementExists(By.XPath(downloading)));

            finished = AdditionalMethods.IsElementDisplayed(driver, completed);

            while (true)
            {
                Thread.Sleep(30000);
                finished = AdditionalMethods.IsElementDisplayed(driver, completed);
                if (finished == true)
                    break;
            }

            Assert.IsTrue(finished);            
        }

        [Test, Order(13)]
        [Ignore("Swipe does not work properly, it does in Appium Studio.")]
        public void LoggedInUsersShoulBeAbleToRemoveADownloadedVideo()
        {
            string completed = "//*[contains(text(),'COMPLETED')]";
            bool finished = false;
            TouchAction action = new TouchAction(driver);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.ClickOn(Hamburger.MenuButton);
            driver.ExecuteScript("seetest:client.swipe(\"Down\", 300, 500)");
            driver.ClickOn(Hamburger.MyDownload);

            while (true)
            {
                finished = AdditionalMethods.IsElementDisplayed(driver, completed);
                if (finished == true)
                {
                    driver.Swipe(457, 348, -29, 348, 552);                  
                    driver.FindElement(By.XPath("//*[@class='UIAView' and ./*[@text='2018 - WEEK 6 - FULL GAME REPLAY']]")).Click();
                }

                else
                    break;
            }
        }
      

        [Test, Order(14)]
        [Ignore("Works Correctly.")]
        public void AnyUserShouldBeAbleToLogOut()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            if (AdditionalMethods.IsElementDisplayed(driver, SignInOutPage.LogOut))
                driver.FindElement(By.XPath(SignInOutPage.LogOut)).Click();
                //driver.ClickOn(SignInOutPage.LogOut);

            bool present = AdditionalMethods.IsElementDisplayed(driver, Hamburger.MenuButton);
            Assert.IsTrue(present);
            //wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

       
    }

}
