using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading.Tasks;
using NUnit.TestsNFL_Android_IOS.Resources;
using NUnit.TestsNFL_Android_IOS.Android_Pages;
using System.Collections.Generic;
using System.Linq;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    [TestFixture]
    class SubscribedUsersTests : BaseTestsAndroid
    {
        //protected AndroidDriver<AndroidElement> driver = null;
        //public WebDriverWait wait;

        //DesiredCapabilities dc = new DesiredCapabilities();

        //[SetUp()]
        //public void SetupTest()
        //{
        //    dc.SetCapability(MobileCapabilityType.Udid, "QLF7N15B14020054");
        //    dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.deltatre.nfl.gamepass");
        //    dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".activities.SplashActivity");

        //    driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), dc);
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //}

        [TestCase("enzofiar", "G1m2P1ss")]
        [Ignore("Work Correctly.")]
        public void UsersShouldBeAbleToLogIn(string userName, string password)
        {
            driver.FindElement(By.XPath(Hamburger.MenuButton));
            driver.FindElement(By.XPath(Hamburger.SignInOut));

            driver.FindElement(By.XPath(SignInOutPage.EmailUsernameField)).SendKeys(userName);
            driver.FindElement(By.XPath(SignInOutPage.PasswordField)).SendKeys(password);
            driver.FindElement(By.XPath(SignInOutPage.LogIn));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [TestCase("//*[@text='10/15/18 - GOOD MORNING FOOTBALL']")]
        [Ignore("Work Correctly.")]
        public void UsersShouldNotBeAbleToAccessContentsInNFLPrograms(string play)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.NFLPrograms))).Click();
            
            string good_morning = NFLPrograms.GoodMorningFootball;

            for(int i = 0; i < 3; i++)
                driver.ExecuteScript("seetest:client.swipe(\"Down\", 0, 500)");
         
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(good_morning))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(play))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));         
        }

        [TestCase("//*[@text='Ep. 5 Browns - Hard Knocks']")]
        [Ignore("Work Correctly.")]
        public void LoggedInUserShouldNotBeAbleToAccessContentsInNFLOriginals(string play)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.NFLOriginals))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton)));

            string hard_knoks = NFLOriginals.HardKnoks;

            for (int i = 0; i < 3; i++)
                driver.ExecuteScript("seetest:client.swipe(\"Down\", 0, 500)");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hard_knoks))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(play))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [TestCase("//*[@id='redzone_item_play' and @height>0]")]
        [Ignore("Work Correctly.")]
        public void UserShouldNotBeAbleToAccessContentsInNFLRedzone(string play)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.NFLRedZone))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton)));

            string script = "seetest:client.swipeWhileNotFound(\"Down\", 0, 2000, \"NATIVE\", \"xpath=ELEM\", 0, 1000, 5, true)";
            script = script.Replace("ELEM", play);
            //driver.ClickOn(play);
            driver.ExecuteScript(script);

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [Test]
        [Ignore("Work Correctly.")]
        public void UsersShoulBeAbleToCheckSubscriptionDetails()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.SignInOut))).Click();
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

        [Test]
        [Ignore("Works Correctly.")]
        public void UsersShoulBeAbleToCheckAccountDetails()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.SignInOut))).Click();
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

        [Test]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessLiveContents()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.NFLNetwork))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='LIVE']"))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

     
        [TestCase("//*[@text='NFL PROGRAMS']")]
        [TestCase("//*[@text='NFL ORIGINALS']")]
        [TestCase("//*[@text='NFL REDZONE']")]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromEveryPage(string page)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(page))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='WATCH NOW' and @width>0]"))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [TestCase("//*[@text='FULL GAME REPLAY']")]
        [TestCase("//*[@text='GAME IN 40']")]
        [TestCase("//*[@text='HIGHLIGHTS']")]
        [TestCase("//*[@text='COACHES FILM']")]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromTeamPage(string mode)
        {
            string team;
            List<string> text = new List<string> { };

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            var elems_page = driver.FindElementsById("menu_item_title");

            foreach (var t in elems_page)
                text.Add(t.GetAttribute("text"));

            team = "//*[@text='" + text[1] + "' and @id='menu_item_title']";
           
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(team))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='WATCH NOW']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(mode))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [TestCase("//*[@text='FULL GAME REPLAY']", "//*[@text='GAMES' and @id='menu_item_title']")]
        [TestCase("//*[@text='GAME IN 40']", "//*[@text='GAMES' and @id='menu_item_title']")]
        [TestCase("//*[@text='HIGHLIGHTS']", "//*[@text='GAMES' and @id='menu_item_title']")]
        [TestCase("//*[@text='COACHES FILM']", "//*[@text='GAMES' and @id='menu_item_title']")]
        [Ignore("Watch Now Not Always Present.")]
        public void LoggedInUsersShouldBeAbleToAccessWatchNowFromGamesPage(string mode, string games)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(games))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='WATCH NOW']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(mode))).Click();

            Thread.Sleep(30000);
            driver.PressKeyCode(AndroidKeyCode.Keycode_BACK);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [TestCase("//*[@text='FULL GAME REPLAY']")]
        [TestCase("//*[@text='GAME IN 40']")]
        [TestCase("//*[@text='HIGHLIGHTS']")]
        [TestCase("//*[@text='COACHES FILM']")]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShouldBeAbleToDownloadAndRemoveVideos(string mode)
        {
            string team;
            List<string> text = new List<string> { };

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            var elems_page = driver.FindElementsById("menu_item_title");

            foreach (var t in elems_page)
                text.Add(t.GetAttribute("text"));

            team = "//*[@text='" + text[1] + "' and @id='menu_item_title']";

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(team))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='WATCH NOW']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='DOWNLOAD']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(mode))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(),'LOW')]"))).Click();
            
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@text='DOWNLOADING']")));
            
            driver.FindElement(By.XPath("xpath=//*[@id='download_button']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@text='SUSPENDED']")));

            int y = Int32.Parse(driver.FindElement(By.XPath("//*[@text='SUSPENDED']")).GetAttribute("y").ToString());            
            int h = driver.Manage().Window.Size.Width - 20;

            driver.Swipe(h, y, 0, y, 2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='YES']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();            
        }

        [TestCase("//*[@text='FULL GAME REPLAY']")]
        [TestCase("//*[@text='GAME IN 40']")]
        [TestCase("//*[@text='HIGHLIGHTS']")]
        [TestCase("//*[@text='COACHES FILM']")]
        [Ignore("Tests could fail but video is downloaded correctly anyway.")]
        public void LoggedInUsersShouldBeAbleToDownloadVideosCompletely(string mode)
        {
            
            string team;
            List<string> text = new List<string> { };

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            var elems_page = driver.FindElementsById("menu_item_title");

            foreach (var t in elems_page)
                text.Add(t.GetAttribute("text"));

            team = "//*[@text='" + text[1] + "' and @id='menu_item_title']";

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(team))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='WATCH NOW']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='DOWNLOAD']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(mode))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(),'LOW')]"))).Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@text='DOWNLOADING']")));

            Thread.Sleep(300000);        
        }

        [Test]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShoulBeAbleToRemoveADownloadedVideo()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MyDownload))).Click();

            int y = Int32.Parse(driver.FindElement(By.XPath("//*[@text='COMPLETED']")).GetAttribute("y").ToString());
            int h = driver.Manage().Window.Size.Width - 20;

            driver.Swipe(h, y, 0, y, 2000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='YES']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
        }

        [Test]
        [Ignore("Works Correctly.")]
        public void LoggedInUsersShoulBeAbleToRemoveAnyDownloadedVideos()
        {
            int y;
            int h = driver.Manage().Window.Size.Width - 20;
            List<int> height = new List<int> { };

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MyDownload))).Click();

            var completed_video = driver.FindElements(By.XPath("//*[@text='COMPLETED']"));

            foreach (var e in completed_video)
                height.Add(Int32.Parse(e.GetAttribute("y").ToString()));

            int min = height.Min();

            foreach (var el in height)
            {
                driver.Swipe(h, min, 0, min, 2000);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='YES']"))).Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Hamburger.MenuButton))).Click();
        }


        //[TearDown()]
        //public void TearDown()
        //{
        //    driver.CloseApp();
        //    driver.Quit();
        //}
    }
}
