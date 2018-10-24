using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class SettingsPage
    {
        //********* Xpath available on the Settings Menu when logged In ******************************************************
        public static string NotificationButton { get; set; } = "//*[@text='NOTIFICATIONS, Allow local notifications 10 minutes before game starting']";
        public static string AllowNotification_ON = "Allow local notifications 10 minutes before game starting";
        public static string AllowNotification_OFF = "";

        public static string ScoresButton { get; set; } = "//*[@text='SCORES, Allow the app to show game scores']";
        public static string Scores_ON = "";
        public static string Scores_OFF = "";

        public static string DownloadsButton { get; set; } = "//*[@text='DOWNLOADS, Download content only if a Wi-Fi   connection is available']";
        public static string Downloads_ON = "";
        public static string Downloads_OFF = "";

        public static string SaveToSDButton { get; set; } = "";
        public static string SaveToSD_ON = "";
        public static string SaveToSD_OFF = "";

        public static string FavoriteTeamButton { get; set; } = "";
        public static string ApplyButton { get; set; } = "";
        public static string OKButton { get; set; } = "";

        public static string NotificationMessage { get; set; } = "";
    }

}
