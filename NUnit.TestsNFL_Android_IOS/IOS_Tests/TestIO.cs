//package <set your test package>;
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
using System.IO;
using System.Text;
using OpenQA.Selenium.Appium.Windows;
using ExportedFromAppiumStudioFirstTest.Resources;
using NUnit.TestsNFL_Android_IOS;
using NUnit.TestsNFL_Android_IOS.DataProvider;

namespace NUnit.TestsNFL_Android_IOS
{
    [TestFixture]
    public class TestIO : BaseTestsIOS
    {
        //[TestCaseSourceAttribute(typeof(XPathProviderIOS), "SetNotifications")]
        //[TestCaseSourceAttribute(typeof(XPathProviderIOS), "GoodMorningFootball")]
        public void SwipeToFindElement(string hamburger, string program, string element)
        {
            AdditionalMethods.TrySwipeAnElement(driver, wait, hamburger, program, element, Offset_Swipe.Full);
        }


        //[Test()]
        public void Click_GoodMorningFootball_OnPage_NFLProgram()
        {
            String hamburger = "xpath=//*[@text='hamburger menu icon']";
            String nfl_program = "xpath=//*[@text='NFL PROGRAMS' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]";
            String good_morning_xpath = "//*[@text='GOOD MORNING FOOTBALL']";

            AdditionalMethods.TrySwipeAnElement(driver, wait, hamburger, nfl_program, good_morning_xpath, Offset_Swipe.Full);
        }

        //[Test()]
        public void SetsNotification_OnSettingsMenu()
        {
            String hamburger = "xpath=//*[@text='hamburger menu icon']";
            String settings = "//*[@text='SETTINGS']";
            String notification = "//*[@text='NOTIFICATIONS, Allow local notifications 10 minutes before game starting']";

            AdditionalMethods.TrySwipeAnElement(driver, wait, hamburger, settings, notification, Offset_Swipe.Full);
        }

        //[Test()]
        public void SubUsersShouldBeAbleToSetNotification()
        {
            String hamburger = "xpath=//*[@text='hamburger menu icon']";
            String settings = "//*[@text='SETTINGS']";
            String notification = "//*[@text='NOTIFICATIONS, Allow local notifications 10 minutes before game starting']";
            String not_text = "NOTIFICATIONS, Allow local notifications 10 minutes before game starting";

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hamburger))).Click();

            if (AdditionalMethods.SwipeWhileNotDisplayed(driver,settings, 5,Offset_Swipe.Half))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(settings))).Click();
                wait.Until(ExpectedConditions.ElementExists(By.XPath(hamburger)));
            }

            AppiumWebElement elem = driver.FindElementByXPath(notification);
            var value = elem.GetAttribute("value");
            var text = elem.GetAttribute("text");
            var visible = elem.GetAttribute("visible");

            if (value == "0")
            {
                elem.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                value = elem.GetAttribute("value");
                Assert.AreEqual("1", value);
            }

            else
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                Assert.AreEqual("1", value);

            }
        }

        //[Test()]
        public void SubUsersShouldBeAbleToSetFavoriteTeam()
        {
            String hamburger = "xpath=//*[@text='hamburger menu icon']";
            String settings = "//*[@text='SETTINGS']";
            String team = "//*[@text='Select your favorite team ']";
            String team_hamb_path = "//*[@text='Jacksonville Jaguars' and ./parent::*[./parent::*[./parent::*[./parent::*[@class='UIACollectionView']]]]]";

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hamburger))).Click();

            if (AdditionalMethods.SwipeWhileNotDisplayed(driver,settings, 5, Offset_Swipe.Half))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(settings))).Click();
                wait.Until(ExpectedConditions.ElementExists(By.XPath(hamburger)));
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(team))).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='Jacksonville Jaguars']"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='APPLY']"))).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='OK']"))).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hamburger))).Click();

            AppiumWebElement elem = driver.FindElementByXPath(team_hamb_path);

            var onScreen = elem.GetAttribute("onScreen");

            Assert.AreEqual("true", onScreen);
        }
    }
}