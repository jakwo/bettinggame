using bettinggame.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bettinggame.data
{
    public class BettingGameDataInitializer
    {
        public static void Seed(BettingGameContext context)
        {
            if (!context.Matches.Any())
            {
                var matchesA = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.FR,
                                               AwayTeam = Country.RO,
                                               Date = new DateTime(2016, 6, 10, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.AL,
                                               AwayTeam = Country.CH,
                                               Date = new DateTime(2016, 6, 11, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RO,
                                               AwayTeam = Country.CH,
                                               Date = new DateTime(2016, 6, 15, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.FR,
                                               AwayTeam = Country.AL,
                                               Date = new DateTime(2016, 6, 15, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CH,
                                               AwayTeam = Country.FR,
                                               Date = new DateTime(2016, 6, 19, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RO,
                                               AwayTeam = Country.AL,
                                               Date = new DateTime(2016, 6, 19, 21, 00, 00)
                                           }
                                   };

                var matchesB = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.WLS,
                                               AwayTeam = Country.SK,
                                               Date = new DateTime(2016, 6, 11, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.EN,
                                               AwayTeam = Country.RU,
                                               Date = new DateTime(2016, 6, 11, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RU,
                                               AwayTeam = Country.SK,
                                               Date = new DateTime(2016, 6, 15, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.EN,
                                               AwayTeam = Country.WLS,
                                               Date = new DateTime(2016, 6, 16, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.SK,
                                               AwayTeam = Country.EN,
                                               Date = new DateTime(2016, 6, 20, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RU,
                                               AwayTeam = Country.WLS,
                                               Date = new DateTime(2016, 6, 20, 21, 00, 00)
                                           }
                                   };

                var matchesC = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.PL,
                                               AwayTeam = Country.NIR,
                                               Date = new DateTime(2016, 6, 12, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.DE,
                                               AwayTeam = Country.UA,
                                               Date = new DateTime(2016, 6, 12, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.UA,
                                               AwayTeam = Country.NIR,
                                               Date = new DateTime(2016, 6, 16, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.DE,
                                               AwayTeam = Country.PL,
                                               Date = new DateTime(2016, 6, 16, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.UA,
                                               AwayTeam = Country.PL,
                                               Date = new DateTime(2016, 6, 21, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.NIR,
                                               AwayTeam = Country.DE,
                                               Date = new DateTime(2016, 6, 21, 18, 00, 00)
                                           }
                                   };

                var matchesD = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.TR,
                                               AwayTeam = Country.HR,
                                               Date = new DateTime(2016, 6, 12, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.ES,
                                               AwayTeam = Country.CZ,
                                               Date = new DateTime(2016, 6, 13, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CZ,
                                               AwayTeam = Country.HR,
                                               Date = new DateTime(2016, 6, 17, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.ES,
                                               AwayTeam = Country.TR,
                                               Date = new DateTime(2016, 6, 17, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.HR,
                                               AwayTeam = Country.ES,
                                               Date = new DateTime(2016, 6, 21, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CZ,
                                               AwayTeam = Country.TR,
                                               Date = new DateTime(2016, 6, 21, 21, 00, 00)
                                           }
                                   };

                var matchesE = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.IE,
                                               AwayTeam = Country.SE,
                                               Date = new DateTime(2016, 6, 13, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.BE,
                                               AwayTeam = Country.IT,
                                               Date = new DateTime(2016, 6, 13, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IT,
                                               AwayTeam = Country.SE,
                                               Date = new DateTime(2016, 6, 17, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.BE,
                                               AwayTeam = Country.IE,
                                               Date = new DateTime(2016, 6, 18, 15, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IT,
                                               AwayTeam = Country.IE,
                                               Date = new DateTime(2016, 6, 22, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.SE,
                                               AwayTeam = Country.BE,
                                               Date = new DateTime(2016, 6, 22, 21, 00, 00)
                                           }
                                   };


                var matchesF = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.AT,
                                               AwayTeam = Country.HU,
                                               Date = new DateTime(2016, 6, 14, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.PT,
                                               AwayTeam = Country.IS,
                                               Date = new DateTime(2016, 6, 14, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IS,
                                               AwayTeam = Country.HU,
                                               Date = new DateTime(2016, 6, 18, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.PT,
                                               AwayTeam = Country.AT,
                                               Date = new DateTime(2016, 6, 18, 21, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.HU,
                                               AwayTeam = Country.PT,
                                               Date = new DateTime(2016, 6, 22, 18, 00, 00)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IS,
                                               AwayTeam = Country.AT,
                                               Date = new DateTime(2016, 6, 22, 18, 00, 00)
                                           }
                                   };

                matchesA.ForEach(x => context.Matches.Add(x));
                matchesB.ForEach(x => context.Matches.Add(x));
                matchesC.ForEach(x => context.Matches.Add(x));
                matchesD.ForEach(x => context.Matches.Add(x));
                matchesE.ForEach(x => context.Matches.Add(x));
                matchesF.ForEach(x => context.Matches.Add(x));

                context.SaveChanges();
            }
        }
    }
}
