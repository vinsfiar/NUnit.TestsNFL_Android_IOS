using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class Hamburger
    {
        //Available on the Hamburger Menu when logged In
        public static string MenuButton { get; set; } = "//*[@text='hamburger menu icon']";
        public static string Games { get; set; } = "//*[@text='GAMES']";
        public static string FavoriteTeam { get; set; } = "";
        public static string NFLNetwork { get; set; } = "//*[@text='NFL NETWORK']";
        public static string NFLPrograms { get; set; } = "//*[@text='NFL PROGRAMS' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIAImage']]";
        public static string NFLOriginals { get; set; } = "//*[@text='NFL ORIGINALS']";
        public static string NFLRedZone { get; set; } = "//*[@text='NFL REDZONE']";
        public static string AllTeams { get; set; } = "//*[@text='ALL TEAMS']";
        public static string MyDownload { get; set; } = "//*[@text='MY DOWNLOADS']";
        public static string Help { get; set; } = "//*[@text='HELP']";
        public static string Settings { get; set; } = "//*[@text='SETTINGS']";
        public static string SignInOut { get; set; } = "(//*[@class='UIAView' and ./parent::*[@class='UIAView' and ./parent::*[@class='UIAView' and (./preceding-sibling::* | ./following-sibling::*)[@class='UIACollectionView'] and ./parent::*[@class='UIAView']]]]/*[@class='UIAImage'])[3]";

        //Available on the Hamburger Menu when not logged In
        public static string Teams { get; set; } = "//*[@text='TEAMS']";
    }
}
