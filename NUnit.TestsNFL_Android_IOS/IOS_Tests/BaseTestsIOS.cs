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
using NUnit.TestsNFL_Android_IOS.Resources;

namespace NUnit.TestsNFL_Android_IOS
{
    public class BaseTestsIOS
    {
        //protected AppiumDriver<AppiumWebElement> driver = null;
        protected IOSDriver<IOSElement> driver = null;
        DesiredCapabilities dc = new DesiredCapabilities();
        public WebDriverWait wait;

        [SetUp()]
        public void SetupTest()
        {
            
            dc.SetCapability(MobileCapabilityType.Udid, "460800825c74ddca90490c4e5394e74e2f01e67c");
            dc.SetCapability(IOSMobileCapabilityType.BundleId, "com.deltatre.nfl.gamepass");
            //driver = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), dc);
            driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), dc);
             
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.ExecuteScript("seetest:client.launch(\"com.deltatre.nfl.gamepass\", \"false\",\"true\")");
            DriverExtension.wait = this.wait;
        }

        [TearDown()]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
        }
    }
}
