using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.Android_Tests
{
    public static class NFLPrograms
    {
        public static string GoodMorningFootball { get; set; } = "//*[@text='GOOD MORNING FOOTBALL' and @width>0]";
        public static string TotalAccess { get; set; } = "//*[@text='TOTAL ACCESS']";
        public static string NFLFantasyLive { get; set; } = "//*[@text='NFL Fantasy Live']";
        public static string NFLGameDayPickEm { get; set; } = "(//*[@class='android.widget.GridLayout']/*/*/*/*[@id='card_nflnetwork_title' and @height>0 and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@height>0]]])[4]";
        public static string GamedayMorning { get; set; } = "//*[@text='Gameday Morning']";
        public static string GamedayLive { get; set; } = "//*[@text='Gameday Live']";
        public static string GamedayHighlights { get; set; } = "//*[@text='Gameday Highlights']";
        public static string GamedayPrime { get; set; } = "//*[@text='Gameday Prime']";
        public static string TheKyleBrandtFootballExperience { get; set; } = "//*[@text='The Kyle Brandt Football Experience']";
        public static string Playbook { get; set; } = "//*[@text='PLAYBOOK']";
        public static string NFLShow { get; set; } = "(//*[@class='android.widget.GridLayout']/*/*/*/*[@id='card_nflnetwork_title' and @height>0 and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@height>0]]])[3]";
        public static string ThisWeek { get; set; } = "//*[@text='THIS WEEK']";
        public static string NFLMICDUp { get; set; } = "(//*[@class='android.widget.GridLayout']/*/*/*/*[@id='card_nflnetwork_title' and @height>0 and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@height>0]]])[5]";
        public static string CoachCorner { get; set; } = "(//*[@class='android.widget.GridLayout']/*/*/*/*[@id='card_nflnetwork_title' and @height>0 and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@height>0]]])[6]";
        public static string NFLCombine2018 { get; set; } = "//*[@text='2018 NFL COMBINE']";
        public static string FreeAgencyFrenzy2018 { get; set; } = "//*[@text='2018 Free Agency Frenzy']";
        public static string NFLDraft2018 { get; set; } = "//*[@text='2018 NFL Draft']";
        public static string TrainingCampPrimetime { get; set; } = "//*[@text='Training Camp Primetime']";


        public static List<string> Programs = new List<string> {
                                                                 GoodMorningFootball,TotalAccess, NFLFantasyLive,NFLGameDayPickEm,
                                                                 GamedayMorning,GamedayLive,GamedayHighlights,GamedayPrime,
                                                                 TheKyleBrandtFootballExperience,Playbook,NFLShow, ThisWeek, NFLMICDUp,
                                                                 CoachCorner,NFLCombine2018,FreeAgencyFrenzy2018,NFLDraft2018,TrainingCampPrimetime
                                                             };


    }
}
