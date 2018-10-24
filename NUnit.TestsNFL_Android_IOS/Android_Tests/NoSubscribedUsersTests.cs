using ExportedFromAppiumStudioFirstTest.Resources;
using NUnit.Framework;
using NUnit.TestsNFL_Android_IOS.Android_Pages;
using NUnit.TestsNFL_Android_IOS.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    [TestFixture]
    //[Ignore("Work Correctly.")]
    class NoSubscribedUsersTests : BaseTestsAndroid
    {
        [TestCase("vinsfiar", "V3nc2nz4")]
        [Ignore("Work Correctly.")]
        public void AnyUserProvidingValidCredentialsShoulBeAbleToLogIn(string userName, string password)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            driver.FindElement(By.XPath(SignInOutPage.EmailUsernameField)).SendKeys(userName);
            driver.FindElement(By.XPath(SignInOutPage.PasswordField)).SendKeys(password);
            driver.ClickOn(SignInOutPage.LogIn);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [Test]
        [Ignore("Work Correctly.")]
        public void LoggedInUsersShouldBeRequiredToSubscribe()
        {
            AppiumWebElement subscribe;
            string subscribe_text;
            List<string> sub_list = new List<string> { Hamburger.Games,
                                                       Hamburger.NFLNetwork,
                                                       Hamburger.NFLOriginals,
                                                       Hamburger.NFLPrograms,
                                                       Hamburger.NFLRedZone
                                                     };
            foreach (var el in sub_list)
            {
                driver.ClickOn(Hamburger.MenuButton);
                driver.ClickOn(el);
                subscribe = driver.FindElement(By.XPath(SubscribePage.SubscribeButton));
                subscribe_text = subscribe.GetAttribute("text");

                Assert.AreEqual("SUBSCRIBE", subscribe_text);
            }
        }

        [TestCase("//*[@id='redzone_item_play' and @height>0]")]
        [Ignore("Work Correctly.")]
        public void LoggedInUserShouldNotBeAbleToAccessContentsInNFLRedzone(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLRedZone);
            string script = "seetest:client.swipeWhileNotFound(\"Down\", 0, 2000, \"NATIVE\", \"xpath=ELEM\", 0, 1000, 5, true)";
            script = script.Replace("ELEM", play);
            //driver.ClickOn(play);
            driver.ExecuteScript(script);

            bool displayed = driver.IsElementDisplayed("//*[@text='ERROR']");
            Assert.IsTrue(displayed);
        }

        [TestCase("//*[@text='10/15/18 - GOOD MORNING FOOTBALL']")]
        [Ignore("Work Correctly.")]
        public void LoggedInUserShouldNotBeAbleToAccessContentsInNFLPrograms(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLPrograms);
            string good_morning = NFLPrograms.GoodMorningFootball;
            
            driver.SwipeWhileNotClickable(good_morning, 5);
            
            driver.ClickOn(play);

            bool displayed = driver.IsElementDisplayed("//*[@text='ERROR']");
            Assert.IsTrue(displayed);
        }

        [TestCase("//*[@text='Ep. 5 Browns - Hard Knocks']")]
        [Ignore("Work Correctly.")]
        public void LoggedInUserShouldNotBeAbleToAccessContentsInNFLOriginals(string play)
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.NFLOriginals);
            string hard_knoks = NFLOriginals.HardKnoks;
            
            driver.SwipeWhileNotClickable(hard_knoks, 5);

            driver.ClickOn(play);

            bool displayed = driver.IsElementDisplayed("//*[@text='ERROR']");
            Assert.IsTrue(displayed);
        }

        [TestCase("//*[@text='FULL GAME REPLAY']")]
        [TestCase("//*[@text='GAME IN 40']")]
        [TestCase("//*[@text='HIGHLIGHTS']")]
        [Ignore("Work Correctly.")]
        public void LoggedInUsersShouldNotBeAbleToAccessContentsInTeamPage(string mode)
        {
            string team; 
            List<string> text = new List<string> { };

            driver.ClickOn(Hamburger.MenuButton);
            var elems_page = driver.FindElementsById("menu_item_title");
           
            foreach (var t in elems_page)
                text.Add(t.GetAttribute("text"));

            team = "//*[@text='" + text[1] + "' and @id='menu_item_title']";
        
            driver.ClickOn(team);

            driver.ClickOn("//*[@text='WATCH NOW']");
            driver.ClickOn(mode);

            bool displayed = driver.IsElementDisplayed("//*[@text='ERROR']");
            Assert.IsTrue(displayed);
        }

        [TestCase("//*[@text='COMPLETED' and @height>0 and (./preceding-sibling::* | ./following-sibling::*)[@height>0]]", 
            "//*[@text='GAME IN 40']")]
        [TestCase("//*[@text='COMPLETED' and @height>0 and (./preceding-sibling::* | ./following-sibling::*)[@height>0]]",
            "//*[@text='HIGHLIGHTS']")]
        [TestCase("//*[@text='COMPLETED' and @height>0 and (./preceding-sibling::* | ./following-sibling::*)[@height>0]]",
            "//*[@text='FULL GAME REPLAY']")]
        [Ignore("Work Correctly.")]
        public void LoggedInUsersShouldNotBeAbleToAccessContentsInGamesPage(string game, string mode)
        {
            //string team = "//*[@text='" + favorite + "' and @id='menu_item_title']";
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.Games);

            string script = "seetest:client.swipeWhileNotFound(\"Down\", 0, 2000, \"NATIVE\", \"xpath=ELEM\", 0, 1000, 5, true)";

            script = script.Replace("ELEM", game);
            driver.ExecuteScript(script);
            driver.ClickOn(mode);

            bool displayed = driver.IsElementDisplayed("//*[@text='ERROR']");
            Assert.IsTrue(displayed);

        }

        [Test]
        [Ignore("Work Correctly.")]
        public void AnyUserShouldBeAbleToLogOut()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);

            driver.ClickOn(SignInOutPage.LogOut);

            wait.Until(ExpectedConditions.ElementExists(By.XPath(Hamburger.MenuButton)));
        }

        [Test]
        [Ignore("Work Correctly.")]
        public void LoggedInUsersShoulBeAbleToCheckAccountDetails()
        {
            driver.ClickOn(Hamburger.MenuButton);
            driver.ClickOn(Hamburger.SignInOut);
           
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
    }
}
