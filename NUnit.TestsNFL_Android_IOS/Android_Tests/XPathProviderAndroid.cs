using NUnit.Framework;
using NUnit.TestsNFL_Android_IOS.Android_Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.DataProvider
{
    class XPathProviderAndroid
    {
        public static List<string> TeamsXpath = new List<string> {
            
                                                        TeamsPage.Ravens,
                                                        TeamsPage.Bills,
                                                        TeamsPage.Bengals,
                                                        TeamsPage.Browns,
                                                        TeamsPage.Broncos,
                                                        TeamsPage.Texans,
                                                        TeamsPage.Colts,
                                                        TeamsPage.Jaguars,
                                                        TeamsPage.Chiefs,
                                                        TeamsPage.Charges,
                                                        TeamsPage.Dolphins,
                                                        TeamsPage.Patriots,
                                                        TeamsPage.Jets,
                                                        TeamsPage.Raiders,
                                                        TeamsPage.Steelers,
                                                        TeamsPage.Titans,
                                                        TeamsPage.Cardinals,
                                                        TeamsPage.Falcons,
                                                        TeamsPage.Panthers,
                                                        TeamsPage.Bears,
                                                        TeamsPage.Cowboys,
                                                        TeamsPage.Lions,
                                                        TeamsPage.Packers,
                                                        TeamsPage.Rams,
                                                        TeamsPage.Vikings,
                                                        TeamsPage.Saints,
                                                        TeamsPage.Giants,
                                                        TeamsPage.Eagles,
                                                        TeamsPage.Seahawks,
                                                        TeamsPage.Ers49,
                                                        TeamsPage.Buccaners,
                                                        TeamsPage.Redskins                                                     
                                                    };
        public static IEnumerable Team
        {
            get
            {
                yield return new TestCaseData(
                    TeamsPage.Ravens,
                    TeamsPage.Bills,
                    TeamsPage.Bengals,
                    TeamsPage.Browns,
                    TeamsPage.Broncos,
                    TeamsPage.Texans,
                    TeamsPage.Colts,
                    TeamsPage.Jaguars,
                    TeamsPage.Chiefs,
                    TeamsPage.Charges,
                    TeamsPage.Dolphins,
                    TeamsPage.Patriots,
                    TeamsPage.Jets,
                    TeamsPage.Raiders,
                    TeamsPage.Steelers,
                    TeamsPage.Titans,
                    TeamsPage.Cardinals,
                    TeamsPage.Falcons,
                    TeamsPage.Panthers,
                    TeamsPage.Bears,
                    TeamsPage.Cowboys,
                    TeamsPage.Lions,
                    TeamsPage.Packers,
                    TeamsPage.Rams,
                    TeamsPage.Vikings,
                    TeamsPage.Saints,
                    TeamsPage.Giants,
                    TeamsPage.Eagles,
                    TeamsPage.Seahawks,
                    TeamsPage.Ers49,
                    TeamsPage.Buccaners,
                    TeamsPage.Redskins                   
                  );
            }
        }
        public static IEnumerable SetNotifications
        {           
            get
            {
                yield return new TestCaseData(
                    Hamburger.MenuButton,
                    Hamburger.Settings,
                    SettingsPage.NotificationButton
               
                  );
            }
        }

        public static IEnumerable GoodMorningFootball
        {
            get
            {
                yield return new TestCaseData(
                  Hamburger.MenuButton,
                  Hamburger.NFLPrograms,
                  NFLPrograms.GoodMorningFootball
                  );
            }
        }
    }
}
