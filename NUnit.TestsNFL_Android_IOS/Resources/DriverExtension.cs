using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Drawing;
using NUnit.TestsNFL_Android_IOS.Android_Tests;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace NUnit.TestsNFL_Android_IOS.Resources
{
    public enum Offset
    {
        Half,
        Full
    }
    public static class DriverExtension
    {
        public static WebDriverWait wait { get; set; }
        public static WebDriverWait android_wait { get; set; }

        public static void ClickOn(this AndroidDriver<AndroidElement> driver, string path)
        {
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path))).Click();
        }

        public static void ClickOn(this IOSDriver<IOSElement> driver, string path)
        {
            if (driver.FindElement(By.XPath(path)).Displayed)
                driver.FindElement(By.XPath(path)).Click();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path))).Click();
        }

        
        //public static void ClickOn(this AppiumDriver<AppiumWebElement> driver, string path)
        //{
        //    //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        //    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(path))).Click();
        //}

    

        /// <summary>
        /// Return true if the element passed is visible, return false otherwise.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsElementDisplayed(this AndroidDriver<AndroidElement> driver, string path)
        {
            try
            {
                return driver.FindElement(By.XPath(path)).Displayed;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(this IOSDriver<IOSElement> driver, string path)
        {
            try
            {
                return driver.FindElement(By.XPath(path)).Displayed;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public static IOSElement ElementDisplayed(this IOSDriver<IOSElement> driver, string path)
        {
            IOSElement element_to_find = null;

            try
            {
                element_to_find = driver.FindElement(By.XPath(path));

                if (element_to_find.Displayed)
                    return element_to_find;

                else
                    return null;
            }

            catch (Exception)
            {
                return null;
            }

        }

        public static AndroidElement ElementDisplayed(this AndroidDriver<AndroidElement> driver, string path)
        {
            AndroidElement element_to_find = null;

            try
            {
                element_to_find = driver.FindElement(By.XPath(path));

                if (element_to_find.Displayed)
                    return element_to_find;

                else
                    return null;
            }

            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Swipes the screen for a maximum of rounds times to find the element passed in, click on the element when found.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xpath"></param>
        /// <param name="rounds"></param>
        /// <param name="off"></param>
        public static void SwipeWhileNotClickable(this AndroidDriver<AndroidElement> driver, string xpath, int rounds, Offset off = Offset.Full)
        {
            int high = driver.Manage().Window.Size.Height;
            String page_half_high = (high / 2).ToString();
            String script_half_page = "seetest:client.swipe(\"Down\", " + page_half_high + ", 500)";
            String script_page = "seetest:client.swipe(\"Down\", 10, 500)";
            String script = script_page;
            int count = 0;
            AppiumWebElement element_to_click = null;


            if (off == Offset.Half)
                script = script_half_page;

            bool element = IsElementDisplayed(driver, xpath);

            while (count <= rounds)
            {
                //driver.ExecuteScript(script);
                //element = IsElementDisplayed(driver, xpath);
                element_to_click = driver.ElementDisplayed(xpath);

                if (element_to_click != null)
                    break;

                else
                    driver.ExecuteScript(script);

                count++;
            }

            element_to_click.Click();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            //driver.FindElement(By.XPath(xpath)).Click();
            //element_to_click.Click();
        } 
    }
}
