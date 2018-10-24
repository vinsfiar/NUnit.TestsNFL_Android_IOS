using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    public static class SettingsPage
    {
        //********* Xpath available on the Settings Menu when logged In ******************************************************
        public static string NotificationButton { get; set; } = "//*[@id='main_settings_notification_switch']";
        public static string AllowNotification_ON = "Allow local notifications 10 minutes before game starting ON";
        public static string AllowNotification_OFF = "Allow local notifications 10 minutes before game starting OFF";

        public static string ScoresButton { get; set; } = "//*[@id='main_settings_results_switch']";
        public static string Scores_ON = "Allow the app to show game scores ON";
        public static string Scores_OFF = "Allow the app to show game scores OFF";

        public static string DownloadsButton { get; set; } = "//*[@id='main_settings_only_wifi_switch']";
        public static string Downloads_ON = "Download content only if a Wi-Fi \r\n connection is available ON";
        public static string Downloads_OFF = "Download content only if a Wi-Fi \r\n connection is available OFF";

        public static string SaveToSDButton { get; set; } = "//*[@id='main_settings_use_sd_switch']";
        public static string SaveToSD_ON = "Allow the app to save downloaded content to SD card ON";
        public static string SaveToSD_OFF = "Allow the app to save downloaded content to SD card OFF";

        public static string FavoriteTeamButton { get; set; } = "//*[@text='FAVORITE TEAM']";
        public static string ApplyButton { get; set; } = "//*[@text='APPLY' and @width>0]";
        public static string OKButton { get; set; } = "//*[@text='OK']";

        public static string NotificationMessage { get; set; } = @"//*[@class='android.widget.LinearLayout' and @width>0 
                                                                   and ./*[@class='android.widget.LinearLayout' 
                                                                   and ./*[@text='NOTIFICATIONS']]]";
    }
}
