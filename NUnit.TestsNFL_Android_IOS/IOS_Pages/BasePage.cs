using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class BasePage
    {
        public static string WatchNowButton { get; set; } = "//*[@text='WATCH NOW']";
        public static string LiveButton { get; set; } = "//*[@text='LIVE']";
        public static string DownloadButton { get; set; } = "//*[@text='DOWNLOAD']";
        public static string LogoutButton { get; set; } = "";
        public static string LogoinButton { get; set; } = "";
        public static string SubscribeButton { get; set; } = "";
    }
}
