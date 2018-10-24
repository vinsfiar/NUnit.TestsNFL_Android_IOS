using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class NFLOriginals
    {
        public static string HardKnoks { get; set; } = "//*[@text='Hard Knocks']";
        public static string GamePreviewsWeek6 { get; set; } = "//*[contains(text(),'Game Preview Week')]";
        public static string AFootballLife { get; set; } = "//*[@text='A Football Life']";
        public static string Top10 { get; set; } = "//*[@text='Top 10']";
        public static string TheAfterMath { get; set; } = "//*[@text='The Aftermath']";
        public static string FilmSession { get; set; } = "//*[@text='Film Session']";
        public static string AmericansGame { get; set; } = "//*[contains(text(),'America')]";
        public static string NFLFilms { get; set; } = "//*[@text='NFL Films']";
        public static string SeasonInPreview { get; set; } = "//*[@text='Season In Review']";
        public static string Undiscovered { get; set; } = "//*[@text='Undiscovered']";
        public static string Top100 { get; set; } = "//*[@text='TOP 100']";
        public static string TimeLine { get; set; } = "//*[@text='Timeline']";
        public static string DestinationDallas { get; set; } = "//*[@text='Destination Dallas ']";
        public static string NFLTurningPoint { get; set; } = "//*[@text='NFL Turning Point']";
        public static string ClassicGame { get; set; } = "//*[@text='Classic Games']";
        public static string FootballTown { get; set; } = "//*[@text='Football Town']";
        public static string GoingGlobal { get; set; } = "//*[@text='Going Global']";
        public static string SuperBowlClassic { get; set; } = "//*[@text='Super Bowl Classics']";
        public static string Undrafted { get; set; } = "//*[@text='Undrafted']";


        public static List<string> ProgramList = new List<string> { HardKnoks, GamePreviewsWeek6, AFootballLife,
                                                              Top10, TheAfterMath, FilmSession, AmericansGame,
                                                              NFLFilms, SeasonInPreview, Undiscovered, Undiscovered,
                                                              Top100, TimeLine, DestinationDallas, NFLTurningPoint,
                                                              ClassicGame, FootballTown, GoingGlobal, SuperBowlClassic,
                                                              Undrafted
                                                            };
    }
}
