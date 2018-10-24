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
using ExportedFromAppiumStudioFirstTest.Resources;
using NUnit.TestsNFL_Android_IOS.Resources;

namespace NUnit.TestsNFL_Android_IOS
{
    [TestFixture]
    public class BaseTestsAndroid
    {
        //protected AppiumDriver<AppiumWebElement> driver = null;
        protected AndroidDriver<AndroidElement> driver = null;
        DesiredCapabilities dc = new DesiredCapabilities();
        public WebDriverWait wait;


        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability(MobileCapabilityType.Udid, "QLF7N15B14020054");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.deltatre.nfl.gamepass");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".activities.SplashActivity");
            
            //driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), dc);
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), dc);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            DriverExtension.wait = this.wait;

        }



        /*
         * protected AndroidDriver<AndroidElement> driver = null;
        public WebDriverWait wait;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability(MobileCapabilityType.Udid, "QLF7N15B14020054");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.deltatre.nfl.gamepass");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".activities.SplashActivity");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), dc);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

         */


        [TearDown()]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
        }
    }
}