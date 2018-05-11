
using bettinggame.api.Models;
using bettinggame.data.Entities;
using bettinggame.data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bettinggame.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class MatchesController : Controller
    {
        private readonly IMatchesRepository _matchesRepository;
        private ITipsRepository _tipsRepository;

        public MatchesController(IMatchesRepository matchesRepository, ITipsRepository tipsRepository)
        {
            _matchesRepository = matchesRepository;
            _tipsRepository = tipsRepository;
        }

        // GET: api/matches
        [HttpGet("user")]
        public IActionResult GetForUser()
        {
            var userName = HttpContext.User.Identity.Name;

            // Create all tips for the user if it's his first login.
            var matches = _matchesRepository.GetAllMatches();
            if (!matches.All(x => x.Tips != null && x.Tips.Any(y => y.User.Equals(userName))))
            {
                var tips = new List<Tip>();
                foreach (var match in matches.Where(x => x.Tips == null || !x.Tips.Any(y => y.User.Equals(userName))))
                {
                    tips.Add(new Tip { User = userName, MatchId = match.Id });
                }

                _tipsRepository.AddTips(tips);
                matches = _matchesRepository.GetAllMatches();
            }

            var matchModels = MapMatches(matches, userName);
            return Ok(matchModels);
        }

        // POST: api/matches/
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateResult([FromBody] MatchModel matchModel)
        {
            var match = _matchesRepository.GetMatch(matchModel.Id);
            if (match != null)
            {
                if (match.Date > DateTime.UtcNow)
                {
                    return BadRequest("Das Spiel ist noch nicht gespielt..");
                }
            }

            _matchesRepository.UpdateMatchResult(matchModel.Id, matchModel.HomeGoals, matchModel.AwayGoals);
            return Ok();
        }


        // GET: api/matches
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var matchModels = MapMatches(_matchesRepository.GetAllMatches(), string.Empty);
            return Ok(matchModels);
        }

        private static IEnumerable<MatchModel> MapMatches(ICollection<Match> matches, string userName)
        {
            var matchModels = from match in matches
                              select
                                  new MatchModel
                                  {
                                      Id = match.Id,
                                      Date = DateTime.SpecifyKind(match.Date, DateTimeKind.Utc),
                                      AwayGoals = match.AwayGoals,
                                      HomeGoals = match.HomeGoals,
                                      HomeTeamFlag = GetFlag(match.HomeTeam).ToLower(),
                                      AwayTeamFlag = GetFlag(match.AwayTeam).ToLower(),
                                      HomeTeam = GetCountry(match.HomeTeam),
                                      AwayTeam = GetCountry(match.AwayTeam),
                                      MatchCompleted = match.Date < DateTime.UtcNow,
                                      Tips = from tip in match.Tips
                                             orderby tip.User
                                             where (match.Date < DateTime.UtcNow || tip.User == userName)
                                             select
                                                 new TipModel
                                                 {
                                                     Id = tip.Id,
                                                     MatchId = tip.MatchId,
                                                     User = tip.User,
                                                     AwayGoals = tip.AwayGoals,
                                                     HomeGoals = tip.HomeGoals
                                                 }
                                  };
            return matchModels;
        }

        private static string GetCountry(Country country)
        {
            switch (country)
            {
                case Country.SaudiArabia:
                    return "Saudi-Arabien";
                case Country.Egypt:
                    return "Ägypten";
                case Country.Russia:
                    return "Russland";
                case Country.Uruguay:
                    return "Uruguay";

                case Country.Iran:
                    return "Iran";
                case Country.Portugal:
                    return "Portugal";
                case Country.Spain:
                    return "Spanien";
                case Country.Morocco:
                    return "Marokko";

                case Country.Peru:
                    return "Peru";
                case Country.Denmark:
                    return "Dänemark";
                case Country.France:
                    return "Frankreich";
                case Country.Australia:
                    return "Australien";

                case Country.Argentina:
                    return "Argentinien";
                case Country.Iceland:
                    return "Island";
                case Country.Croatia:
                    return "Kroatien";
                case Country.Nigeria:
                    return "Nigeria";

                case Country.Serbia:
                    return "Serbien";
                case Country.Brazil:
                    return "Brasilien";
                case Country.Switzerland:
                    return "Schweiz";
                case Country.CostaRica:
                    return "Costa Rica";

                case Country.Mexico:
                    return "Mexico";
                case Country.Germany:
                    return "Deutschland";
                case Country.Sweden:
                    return "Schweden";
                case Country.KoreaRepublic:
                    return "Südkorea";

                case Country.Tunisia:
                    return "Tunesien";
                case Country.Panama:
                    return "Panama";
                case Country.Belgium:
                    return "Belgien";
                case Country.England:
                    return "England";

                case Country.Japan:
                    return "Japan";
                case Country.Poland:
                    return "Polen";
                case Country.Colombia:
                    return "Kolumbien";
                case Country.Senegal:
                    return "Senegal";
                default:
                    return string.Empty;
            }
        }

        private static string GetFlag(Country country)
        {
            switch (country)
            {
                case Country.SaudiArabia:
                    return "SA";
                case Country.Egypt:
                    return "EG";
                case Country.Russia:
                    return "RU";
                case Country.Uruguay:
                    return "UY";

                case Country.Iran:
                    return "IR";
                case Country.Portugal:
                    return "PT";
                case Country.Spain:
                    return "ES";
                case Country.Morocco:
                    return "MA";

                case Country.Peru:
                    return "PE";
                case Country.Denmark:
                    return "DK";
                case Country.France:
                    return "FR";
                case Country.Australia:
                    return "AU";

                case Country.Argentina:
                    return "AR";
                case Country.Iceland:
                    return "IS";
                case Country.Croatia:
                    return "HR";
                case Country.Nigeria:
                    return "NG";

                case Country.Serbia:
                    return "RS";
                case Country.Brazil:
                    return "BR";
                case Country.Switzerland:
                    return "CH";
                case Country.CostaRica:
                    return "CR";

                case Country.Mexico:
                    return "MX";
                case Country.Germany:
                    return "DE";
                case Country.Sweden:
                    return "SE";
                case Country.KoreaRepublic:
                    return "KR";

                case Country.Tunisia:
                    return "TN";
                case Country.Panama:
                    return "PA";
                case Country.Belgium:
                    return "BE";
                case Country.England:
                    return "GB";

                case Country.Japan:
                    return "JP";
                case Country.Poland:
                    return "PL";
                case Country.Colombia:
                    return "CO";
                case Country.Senegal:
                    return "SN";
                default:
                    return country.ToString().ToLower();
            }
        }
    }
}
