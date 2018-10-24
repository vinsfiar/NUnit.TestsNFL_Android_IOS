using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    public static class BasePage
    {
        public static string WatchNowButton { get; set; } = "//*[@text='WATCH NOW' and @width>0]";
        public static string LiveButton { get; set; } = "//*[@text='LIVE']";
        public static string DownloadButton { get; set; } = "//*[@text='DOWNLOAD']";
        public static string LogoutButton { get; set; } = "//*[@text='LOGOUT']";
        public static string LogoinButton { get; set; } = "//*[@text='LOGIN' and @width>0]";
        public static string SubscribeButton { get; set; } = "//*[@text='SUBSCRIBE' and @width>0]";
    }
}
