using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Pages
{
    public static class SubscribePage
    {
        public static string BuyNow { get; set; } = @"//*[@text='BUY NOW' and (./preceding-sibling::* 
                                                    | ./following-sibling::*)[@text='Annual Subscription']]";
        public static string FreeTrial { get; set; } = "//*[@text='START 7 DAY FREE TRIAL']";

        public static string SignUp { get; set; } = "//*[@text='Sign Up']";

        public static string SubscribeButton { get; set; } = "//*[@text='SUBSCRIBE' and @width>0]";
    }
}
