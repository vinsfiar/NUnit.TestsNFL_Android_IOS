using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class NFLPrograms
    {
        public static string GoodMorningFootball { get; set; } = "//*[@text='GOOD MORNING FOOTBALL']";
        public static string TotalAccess { get; set; } = "//*[@text='TOTAL ACCESS']";
        public static string NFLFantasyLive { get; set; } = "//*[@text='NFL Fantasy Live']";
        public static string NFLGameDayPickEm { get; set; } = "//*[contains(text(),'NFL Gameday Pick')]";
        public static string GamedayMorning { get; set; } = "//*[@text='Gameday Morning']";
        public static string GamedayLive { get; set; } = "//*[@text='Gameday Live']";
        public static string GamedayHighlights { get; set; } = "//*[@text='Gameday Highlights']";
        public static string GamedayPrime { get; set; } = "//*[@text='Gameday Prime']";
        public static string TheKyleBrandtFootballExperience { get; set; } = "//*[@text='The Kyle Brandt Football Experience']";
        public static string Playbook { get; set; } = "//*[@text='PLAYBOOK']";
        public static string NFLShow { get; set; } = "//*[@text='NFL SHOW\\n']";
        public static string ThisWeek { get; set; } = "//*[@text='THIS WEEK']";
        public static string NFLMICDUp { get; set; } = "//*[contains(text(),'NFL MIC')]";
        public static string CoachCorner { get; set; } = "//*[contains(text(),'Coach')]";
        public static string NFLCombine2018 { get; set; } = "//*[contains(text(),'NFL Combine')]";
        public static string FreeAgencyFrenzy2018 { get; set; } = "//*[contains(text(),'Free Agency Frenzy')]";
        public static string NFLDraft2018 { get; set; } = "//*[contains(text(),'NFL Draft')]";
        public static string TrainingCampPrimetime { get; set; } = "//*[@text='Training Camp Primetime']";


        public static List<string> Programs = new List<string> {
                                                                 GoodMorningFootball,TotalAccess, NFLFantasyLive,NFLGameDayPickEm,
                                                                 GamedayMorning,GamedayLive,GamedayHighlights,GamedayPrime,
                                                                 TheKyleBrandtFootballExperience,Playbook,NFLShow, ThisWeek, NFLMICDUp,
                                                                 CoachCorner,NFLCombine2018,FreeAgencyFrenzy2018,NFLDraft2018,TrainingCampPrimetime
                                                             };


    }
}
