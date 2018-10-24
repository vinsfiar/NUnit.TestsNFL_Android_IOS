using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class TeamsPage
    {
        public static string Ravens { get; set; } = "//*[@text='Baltimore Ravens']";
        public static string Bills { get; set; } = "//*[@text='Buffalo Bills']";
        public static string Bengals { get; set; } = "//*[@text='Cincinnati Bengals']";
        public static string Browns { get; set; } = "//*[@text='Cleveland Browns']";
        public static string Broncos { get; set; } = "//*[@text='Denver Broncos']";
        public static string Texans { get; set; } = "//*[@text='Houston Texans']";
        public static string Colts { get; set; } = "//*[@text='Indianapolis Colts']";
        public static string Jaguars { get; set; } = "//*[@text='Jacksonville Jaguars']";
        public static string Chiefs { get; set; } = "//*[@text='Kansas City Chiefs']";
        public static string Charges { get; set; } = "//*[@text='Los Angeles Chargers']";
        public static string Dolphins { get; set; } = "//*[@text='Miami Dolphins']";
        public static string Patriots { get; set; } = "//*[@text='New England Patriots']";
        public static string Jets { get; set; } = "//*[@text='New York Jets']";
        public static string Raiders { get; set; } = "//*[@text='Oakland Raiders']";
        public static string Steelers { get; set; } = "//*[@text='Pittsburgh Steelers']";
        public static string Titans { get; set; } = "//*[@text='Tennessee Titans']";
        public static string Cardinals { get; set; } = "//*[@text='Arizona Cardinals']";
        public static string Falcons { get; set; } = "//*[@text='Atlanta Falcons']";
        public static string Panthers { get; set; } = "//*[@text='Carolina Panthers']";
        public static string Bears { get; set; } = "//*[@text='Chicago Bears']";
        public static string Cowboys { get; set; } = "//*[@text='Dallas Cowboys']";
        public static string Lions { get; set; } = "//*[@text='Detroit Lions']";
        public static string Packers { get; set; } = "//*[@text='Green Bay Packers']";
        public static string Rams { get; set; } = "//*[@text='Los Angeles Rams']";
        public static string Vikings { get; set; } = "//*[@text='Minnesota Vikings']";
        public static string Saints { get; set; } = "//*[@text='New Orleans Saints']";
        public static string Giants { get; set; } = "//*[@text='New York Giants']";
        public static string Eagles { get; set; } = "//*[@text='Philadelphia Eagles']";
        public static string Seahawks { get; set; } = "//*[@text='Seattle Seahawks']";
        public static string Ers49 { get; set; } = "//*[@text='San Francisco 49ers']";
        public static string Buccaners { get; set; } = "//*[@text='Tampa Bay Buccaneers']";
        public static string Redskins { get; set; } = "//*[@text='Washington Redskins']";

        public static List<string> Teams = new List<string> { "BRONCOS", "BILLS", "BENGALS", "BROWNS", "BRONCOS", "TEXANS", "COLTS",
                                                              "JAGUARS","CHIEFS","CHARGES","DOLPHINS","PATRIOTS", "JETS", "RAIDERS",
                                                               "STEELERS","TITANS","CARDINALS","FALCONS","PANTHERS","BEARS","COWBOYS",
                                                               "LIONS", "PACKERS","VIKINGS","SAINTS","GIANTS","EAGLES","SEHAWKS","EARS49",
                                                                "BUCCANERS","REDSKINS"};

    }
}
