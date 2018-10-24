using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS
{
    //[TestFixture]
    public class ConnectionsTests
    {
        protected AppiumDriver<AppiumWebElement> driver = null;
        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp]
        public void SetUp()
        {
            dc.SetCapability(MobileCapabilityType.Udid, "QLF7N15B14020054");
            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), dc);
        }

        //[Test(), Order(1)]
        public void SetAirplainMode()
        {
            ((AndroidDriver<OpenQA.Selenium.Appium.AppiumWebElement>)driver).ConnectionType = ConnectionType.AirplaneMode;

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Assert.AreEqual(ConnectionType.AirplaneMode, ((AndroidDriver<AppiumWebElement>)driver).ConnectionType);
        }

        //[Test(), Order(2)]
        public void SetMobileConnection()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            ((AndroidDriver<OpenQA.Selenium.Appium.AppiumWebElement>)driver).ConnectionType = ConnectionType.DataOnly;
            
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            Assert.AreEqual(ConnectionType.DataOnly, ((AndroidDriver<AppiumWebElement>)driver).ConnectionType);
        }

        
        [TearDown()]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
        }
    }
}
