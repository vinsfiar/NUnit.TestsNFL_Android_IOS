using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.DataProvider
{
    class XPathProviderIOS
    {
        public static IEnumerable SetNotifications
        {
            get
            {
                yield return new TestCaseData(
                  "xpath=//*[@text='hamburger menu icon']",
                  "//*[@text='SETTINGS']",
                  "//*[@text='NOTIFICATIONS, Allow local notifications 10 minutes before game starting']"
                  );
            }
        }

        public static IEnumerable GoodMorningFootball
        {
            get
            {
                yield return new TestCaseData(
                  "xpath=//*[@text='hamburger menu icon']",
                  "xpath=//*[@text='NFL PROGRAMS' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]",
                  "//*[@text='GOOD MORNING FOOTBALL']"
                  );

            }
        }
    }
}
