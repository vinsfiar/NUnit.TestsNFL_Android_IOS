using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;

namespace ExportedFromAppiumStudioFirstTest.Resources
{
    /// <summary>
    /// Rapresents the Swipe amount:
    /// Full = swipe has to take the entire screen size in pixels
    /// Half = swipe has to take half of the screen size in pixel
    /// </summary>
    public enum Offset_Swipe
    {
        Half,
        Full
    }

    /// <summary>
    /// Reimplements some methods already present in OpenQA.Selenium.Appium with more functionalities.
    /// </summary>
    static class AdditionalMethods
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        //public static void FindAllElementsIn(AppiumDriver<AppiumWebElement> driver, List<string> items)
        //{
        //    string base_script = "seetest:client.swipeWhileNotFound(\"DOWN\", 0, 2000, 'NATIVE', \"xpath=ELEMENT\", 0, 1000, 5, false)";
        //    string result, script, found, method_arg, expected;
        //    JObject Mytext;

        //    foreach (var elem in items)
        //    {
        //        script = base_script.Replace("ELEMENT", elem);
        //        result = (string)driver.ExecuteScript(script);
        //        Mytext = JObject.Parse(result);

        //        found = (string)Mytext["found"];
        //        expected = "xpath=" + elem.ToString();
        //        method_arg = (string)Mytext["methodArgs"][4];

        //        Assert.AreEqual(expected, method_arg);
        //        Assert.AreEqual("True", found);
        //    }
        //}


        public static void FindAllElementsIn(AndroidDriver<AndroidElement> driver, List<string> items)
        {
            string base_script = "seetest:client.swipeWhileNotFound(\"DOWN\", 0, 2000, 'NATIVE', \"xpath=ELEMENT\", 0, 1000, 5, false)";
            string result, script, found, method_arg, expected;
            JObject Mytext;

            foreach (var elem in items)
            {
                script = base_script.Replace("ELEMENT", elem);
                result = (string)driver.ExecuteScript(script);
                Mytext = JObject.Parse(result);

                found = (string)Mytext["found"];
                expected = "xpath=" + elem.ToString();
                method_arg = (string)Mytext["methodArgs"][4];

                Assert.AreEqual(expected, method_arg);
                Assert.AreEqual("True", found);
            }
        }

        public static void FindAllElementsIn(IOSDriver<IOSElement> driver, List<string> items)
        {
            string base_script = "seetest:client.swipeWhileNotFound(\"DOWN\", 0, 2000, 'NATIVE', \"xpath=ELEMENT\", 0, 1000, 5, false)";
            string result, script, found, method_arg, expected;
            JObject Mytext;

            foreach (var elem in items)
            {
                script = base_script.Replace("ELEMENT", elem);
                result = (string)driver.ExecuteScript(script);
                Mytext = JObject.Parse(result);

                found = (string)Mytext["found"];
                expected = "xpath=" + elem.ToString();
                method_arg = (string)Mytext["methodArgs"][4];

                Assert.AreEqual(expected, method_arg);
                Assert.AreEqual("True", found);
            }
        }



        /// <summary>
        /// Determine wheter an element is displayed on the screen or not.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsElementDisplayed(AndroidDriver<AndroidElement> driver, string path)
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

        public static bool IsElementDisplayed(IOSDriver<IOSElement> driver, string path)
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

        /// <summary>
        /// Swipe the screen until the element is displayed. It does not click on the element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xpath"></param>
        /// <param name="off"></param>
        /// <returns></returns>
        public static bool SwipeWhileNotDisplayed(AndroidDriver<AndroidElement> driver, string xpath, int rounds, Offset_Swipe off = Offset_Swipe.Full)
        {
            int high = driver.Manage().Window.Size.Height;
            String page_half_high = (high / 2 ).ToString();
            String script_half_page = "seetest:client.swipe(\"Down\", " + page_half_high + ", 500)";
            String script_page = "seetest:client.swipe(\"Down\", 10, 500)";
            String script = script_page;
            int count = 0;


            if (off == Offset_Swipe.Half)
                script = script_half_page;

            try
            {
                bool element = IsElementDisplayed(driver, xpath);

                    while (count <= rounds)
                    {
                        driver.ExecuteScript(script);
                        element = IsElementDisplayed(driver, xpath);

                    if (element)
                        break;

                    count++;
                    }

                return driver.FindElement(By.XPath(xpath)).Displayed;         
            }

            catch (Exception)
            {
                return false;
            }
        }

        public static bool SwipeWhileNotDisplayed(IOSDriver<IOSElement> driver, string xpath, int rounds, Offset_Swipe off = Offset_Swipe.Full)
        {
            int high = driver.Manage().Window.Size.Height;
            String page_half_high = (high / 2).ToString();
            String script_half_page = "seetest:client.swipe(\"Down\", " + page_half_high + ", 500)";
            String script_page = "seetest:client.swipe(\"Down\", 10, 500)";
            String script = script_page;
            int count = 0;


            if (off == Offset_Swipe.Half)
                script = script_half_page;

            try
            {
                bool element = IsElementDisplayed(driver, xpath);

                while (count <= rounds)
                {
                    driver.ExecuteScript(script);
                    element = IsElementDisplayed(driver, xpath);

                    if (element)
                        break;

                    count++;
                }

                return driver.FindElement(By.XPath(xpath)).Displayed;
            }

            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Try swipping an element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="wait"></param>
        /// <param name="hamburger"></param>
        /// <param name="page_program"></param>
        /// <param name="element"></param>
        /// <param name="off"></param>
        //public static void TrySwipeAnElement(AppiumDriver<AppiumWebElement> driver, WebDriverWait wait, String hamburger, String page_program, String element, Offset_Swipe off)
        //{
        //    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        //    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hamburger))).Click();

        //    if (SwipeWhileNotDisplayed(driver, page_program, 5, Offset_Swipe.Half))
        //    {
        //        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(page_program))).Click();
        //        wait.Until(ExpectedConditions.ElementExists(By.XPath(hamburger)));

        //        if (SwipeWhileNotDisplayed(driver, element, 5, off))
        //        {
        //            driver.FindElement(By.XPath(element)).Click();
        //            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        //        }
        //    }
        //}

        public static void TrySwipeAnElement(IOSDriver<IOSElement> driver, WebDriverWait wait, String hamburger, String page_program, String element, Offset_Swipe off)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(hamburger))).Click();

            if (SwipeWhileNotDisplayed(driver, page_program, 5, Offset_Swipe.Half))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(page_program))).Click();
                wait.Until(ExpectedConditions.ElementExists(By.XPath(hamburger)));

                if (SwipeWhileNotDisplayed(driver, element, 5, off))
                {
                    driver.FindElement(By.XPath(element)).Click();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                }
            }
        }

        /// <summary>
        /// Swipe the screen until the element is clickable and click on it.
        /// </summary>
        /// <param name="xpath">Element to be found</param>
        /// <param name="rounds">Set the maximum number of swipe</param>
        /// <param name="off"></param>
        public static void SwipeWhileNotClickable(AndroidDriver<AndroidElement> driver, string xpath, int rounds, Offset_Swipe off = Offset_Swipe.Full)
        {
            int high = driver.Manage().Window.Size.Height;
            String page_half_high = (high / 2).ToString();
            String script_half_page = "seetest:client.swipe(\"Down\", " + page_half_high + ", 500)";
            String script_page = "seetest:client.swipe(\"Down\", 10, 500)";
            String script = script_page;
            int count = 0;
            IWebElement element_to_click = null;


            if (off == Offset_Swipe.Half)
                script = script_half_page;

             bool element = IsElementDisplayed(driver,xpath);

             while (count <= rounds)
             {
                driver.ExecuteScript(script);
                element = IsElementDisplayed(driver, xpath);

                if (element)
                {
                    element_to_click = driver.FindElement(By.XPath(xpath));
                    break;
                }
                driver.ExecuteScript(script);
                count++;
             }

            element_to_click = driver.FindElement(By.XPath(xpath));
            element_to_click.Click();
        }

        public static void SwipeWhileNotClickable(IOSDriver<IOSElement> driver, string xpath, int rounds, Offset_Swipe off = Offset_Swipe.Full)
        {
            int high = driver.Manage().Window.Size.Height;
            String page_half_high = (high / 2).ToString();
            String script_half_page = "seetest:client.swipe(\"Down\", " + page_half_high + ", 500)";
            String script_page = "seetest:client.swipe(\"Down\", 10, 500)";
            String script = script_page;
            int count = 0;
            IWebElement element_to_click = null;


            if (off == Offset_Swipe.Half)
                script = script_half_page;

            bool element = IsElementDisplayed(driver, xpath);

            while (count <= rounds)
            {
                driver.ExecuteScript(script);
                element = IsElementDisplayed(driver, xpath);

                if (element)
                {
                    element_to_click = driver.FindElement(By.XPath(xpath));
                    break;
                }
                driver.ExecuteScript(script);
                count++;
            }

            element_to_click = driver.FindElement(By.XPath(xpath));
            element_to_click.Click();
        }
    }
}
