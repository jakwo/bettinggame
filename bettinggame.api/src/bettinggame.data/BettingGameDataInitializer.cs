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
                var matches = new List<Match>
                {
                                        new Match{HomeTeam = Country.Russia,AwayTeam = Country.SaudiArabia,Date = new DateTime(2018, 06, 14, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Egypt,AwayTeam = Country.Uruguay,Date = new DateTime(2018, 06, 15, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Morocco,AwayTeam = Country.Iran,Date = new DateTime(2018, 06, 15, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Portugal,AwayTeam = Country.Spain,Date = new DateTime(2018, 06, 15, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.France,AwayTeam = Country.Australia,Date = new DateTime(2018, 06, 16, 10, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Argentina,AwayTeam = Country.Iceland,Date = new DateTime(2018, 06, 16, 13, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Peru,AwayTeam = Country.Denmark,Date = new DateTime(2018, 06, 16, 16, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Croatia,AwayTeam = Country.Nigeria,Date = new DateTime(2018, 06, 16, 19, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.CostaRica,AwayTeam = Country.Serbia,Date = new DateTime(2018, 06, 17, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Germany,AwayTeam = Country.Mexico,Date = new DateTime(2018, 06, 17, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Brazil,AwayTeam = Country.Switzerland,Date = new DateTime(2018, 06, 17, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Sweden,AwayTeam = Country.KoreaRepublic,Date = new DateTime(2018, 06, 18, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Belgium,AwayTeam = Country.Panama,Date = new DateTime(2018, 06, 18, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Tunisia,AwayTeam = Country.England,Date = new DateTime(2018, 06, 18, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Colombia,AwayTeam = Country.Japan,Date = new DateTime(2018, 06, 19, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Poland,AwayTeam = Country.Senegal,Date = new DateTime(2018, 06, 19, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Russia,AwayTeam = Country.Egypt,Date = new DateTime(2018, 06, 19, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Portugal,AwayTeam = Country.Morocco,Date = new DateTime(2018, 06, 20, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Uruguay,AwayTeam = Country.SaudiArabia,Date = new DateTime(2018, 06, 20, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Iran,AwayTeam = Country.Spain,Date = new DateTime(2018, 06, 20, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Denmark,AwayTeam = Country.Australia,Date = new DateTime(2018, 06, 21, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.France,AwayTeam = Country.Peru,Date = new DateTime(2018, 06, 21, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Argentina,AwayTeam = Country.Croatia,Date = new DateTime(2018, 06, 21, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Brazil,AwayTeam = Country.CostaRica,Date = new DateTime(2018, 06, 22, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Nigeria,AwayTeam = Country.Iceland,Date = new DateTime(2018, 06, 22, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Serbia,AwayTeam = Country.Switzerland,Date = new DateTime(2018, 06, 22, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Belgium,AwayTeam = Country.Tunisia,Date = new DateTime(2018, 06, 23, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.KoreaRepublic,AwayTeam = Country.Mexico,Date = new DateTime(2018, 06, 23, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Germany,AwayTeam = Country.Sweden,Date = new DateTime(2018, 06, 23, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.England,AwayTeam = Country.Panama,Date = new DateTime(2018, 06, 24, 12, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Japan,AwayTeam = Country.Senegal,Date = new DateTime(2018, 06, 24, 15, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Poland,AwayTeam = Country.Colombia,Date = new DateTime(2018, 06, 24, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Uruguay,AwayTeam = Country.Russia,Date = new DateTime(2018, 06, 25, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.SaudiArabia,AwayTeam = Country.Egypt,Date = new DateTime(2018, 06, 25, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Iran,AwayTeam = Country.Portugal,Date = new DateTime(2018, 06, 25, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Spain,AwayTeam = Country.Morocco,Date = new DateTime(2018, 06, 25, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Denmark,AwayTeam = Country.France,Date = new DateTime(2018, 06, 26, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Australia,AwayTeam = Country.Peru,Date = new DateTime(2018, 06, 26, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Nigeria,AwayTeam = Country.Argentina,Date = new DateTime(2018, 06, 26, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Iceland,AwayTeam = Country.Croatia,Date = new DateTime(2018, 06, 26, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Mexico,AwayTeam = Country.Sweden,Date = new DateTime(2018, 06, 27, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.KoreaRepublic,AwayTeam = Country.Germany,Date = new DateTime(2018, 06, 27, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Serbia,AwayTeam = Country.Brazil,Date = new DateTime(2018, 06, 27, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Switzerland,AwayTeam = Country.CostaRica,Date = new DateTime(2018, 06, 27, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Japan,AwayTeam = Country.Poland,Date = new DateTime(2018, 06, 28, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Senegal,AwayTeam = Country.Colombia,Date = new DateTime(2018, 06, 28, 14, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.Panama,AwayTeam = Country.Tunisia,Date = new DateTime(2018, 06, 28, 18, 00, 00, DateTimeKind.Utc)},
new Match{HomeTeam = Country.England,AwayTeam = Country.Belgium,Date = new DateTime(2018, 06, 28, 18, 00, 00, DateTimeKind.Utc)},

                };



                matches.ForEach(x => context.Matches.Add(x));
                //    //matchesB.ForEach(x => context.Matches.Add(x));
                //    //matchesC.ForEach(x => context.Matches.Add(x));
                //    //matchesD.ForEach(x => context.Matches.Add(x));
                //    //matchesE.ForEach(x => context.Matches.Add(x));
                //    //matchesF.ForEach(x => context.Matches.Add(x));

                context.SaveChanges();
            }
        }
    }
}
