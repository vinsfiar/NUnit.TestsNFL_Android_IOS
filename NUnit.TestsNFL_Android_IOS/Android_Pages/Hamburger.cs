using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    public static class Hamburger
    {
        //Available on the Hamburger Menu when logged In
        public static string MenuButton { get; set; } = "xpath=//*[@contentDescription='Navigate up']";
        public static string Games { get; set; } = "//*[@text='GAMES']";
        public static string FavoriteTeam { get; set; } = "";
        public static string NFLNetwork { get; set; } = "//*[@text='NFL NETWORK']";
        public static string NFLPrograms { get; set; } = "xpath=//*[@text='NFL PROGRAMS' and @id='menu_item_title']";
        public static string NFLOriginals { get; set; } = "//*[@text='NFL ORIGINALS']";
        public static string NFLRedZone { get; set; } = "//*[@text='NFL REDZONE']";
        public static string AllTeams { get; set; } = "//*[@text='ALL TEAMS']";
        public static string MyDownload { get; set; } = "//*[@text='MY DOWNLOADS']";
        public static string Help { get; set; } = "//*[@text='HELP']";
        public static string Settings { get; set; } = "//*[@text='SETTINGS']";
        public static string SignInOut { get; set; } = "//*[@id='menu_login_image' and @width>0]";

        //Available on the Hamburger Menu when not logged In
        public static string Teams { get; set; } = "//*[@text='TEAMS' and @id='menu_item_title']";
    }
}
