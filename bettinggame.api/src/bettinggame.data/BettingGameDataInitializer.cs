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
                                               Date = new DateTime(2016, 6, 10, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.AL,
                                               AwayTeam = Country.CH,
                                               Date = new DateTime(2016, 6, 11, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RO,
                                               AwayTeam = Country.CH,
                                               Date = new DateTime(2016, 6, 15, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.FR,
                                               AwayTeam = Country.AL,
                                               Date = new DateTime(2016, 6, 15, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CH,
                                               AwayTeam = Country.FR,
                                               Date = new DateTime(2016, 6, 19, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RO,
                                               AwayTeam = Country.AL,
                                               Date = new DateTime(2016, 6, 19, 19, 00, 00, DateTimeKind.Utc)
                                           }
                                   };

                var matchesB = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.WLS,
                                               AwayTeam = Country.SK,
                                               Date = new DateTime(2016, 6, 11, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.EN,
                                               AwayTeam = Country.RU,
                                               Date = new DateTime(2016, 6, 11, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RU,
                                               AwayTeam = Country.SK,
                                               Date = new DateTime(2016, 6, 15, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.EN,
                                               AwayTeam = Country.WLS,
                                               Date = new DateTime(2016, 6, 16, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.SK,
                                               AwayTeam = Country.EN,
                                               Date = new DateTime(2016, 6, 20, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.RU,
                                               AwayTeam = Country.WLS,
                                               Date = new DateTime(2016, 6, 20, 19, 00, 00, DateTimeKind.Utc)
                                           }
                                   };

                var matchesC = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.PL,
                                               AwayTeam = Country.NIR,
                                               Date = new DateTime(2016, 6, 12, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.DE,
                                               AwayTeam = Country.UA,
                                               Date = new DateTime(2016, 6, 12, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.UA,
                                               AwayTeam = Country.NIR,
                                               Date = new DateTime(2016, 6, 16, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.DE,
                                               AwayTeam = Country.PL,
                                               Date = new DateTime(2016, 6, 16, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.UA,
                                               AwayTeam = Country.PL,
                                               Date = new DateTime(2016, 6, 21, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.NIR,
                                               AwayTeam = Country.DE,
                                               Date = new DateTime(2016, 6, 21, 16, 00, 00, DateTimeKind.Utc)
                                           }
                                   };

                var matchesD = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.TR,
                                               AwayTeam = Country.HR,
                                               Date = new DateTime(2016, 6, 12, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.ES,
                                               AwayTeam = Country.CZ,
                                               Date = new DateTime(2016, 6, 13, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CZ,
                                               AwayTeam = Country.HR,
                                               Date = new DateTime(2016, 6, 17, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.ES,
                                               AwayTeam = Country.TR,
                                               Date = new DateTime(2016, 6, 17, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.HR,
                                               AwayTeam = Country.ES,
                                               Date = new DateTime(2016, 6, 21, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.CZ,
                                               AwayTeam = Country.TR,
                                               Date = new DateTime(2016, 6, 21, 19, 00, 00, DateTimeKind.Utc)
                                           }
                                   };

                var matchesE = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.IE,
                                               AwayTeam = Country.SE,
                                               Date = new DateTime(2016, 6, 13, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.BE,
                                               AwayTeam = Country.IT,
                                               Date = new DateTime(2016, 6, 13, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IT,
                                               AwayTeam = Country.SE,
                                               Date = new DateTime(2016, 6, 17, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.BE,
                                               AwayTeam = Country.IE,
                                               Date = new DateTime(2016, 6, 18, 13, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IT,
                                               AwayTeam = Country.IE,
                                               Date = new DateTime(2016, 6, 22, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.SE,
                                               AwayTeam = Country.BE,
                                               Date = new DateTime(2016, 6, 22, 19, 00, 00, DateTimeKind.Utc)
                                           }
                                   };


                var matchesF = new List<Match>
                                   {
                                       new Match
                                           {
                                               HomeTeam = Country.AT,
                                               AwayTeam = Country.HU,
                                               Date = new DateTime(2016, 6, 14, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.PT,
                                               AwayTeam = Country.IS,
                                               Date = new DateTime(2016, 6, 14, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IS,
                                               AwayTeam = Country.HU,
                                               Date = new DateTime(2016, 6, 18, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.PT,
                                               AwayTeam = Country.AT,
                                               Date = new DateTime(2016, 6, 18, 19, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.HU,
                                               AwayTeam = Country.PT,
                                               Date = new DateTime(2016, 6, 22, 16, 00, 00, DateTimeKind.Utc)
                                           },
                                       new Match
                                           {
                                               HomeTeam = Country.IS,
                                               AwayTeam = Country.AT,
                                               Date = new DateTime(2016, 6, 22, 16, 00, 00, DateTimeKind.Utc)
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
