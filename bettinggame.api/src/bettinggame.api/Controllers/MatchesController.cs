
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
        [HttpGet("{userName}")]
        public IActionResult GetForUser(string userName)
        {
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

            var matchModels = MapMatches(matches);
            return Ok(matchModels);
        }

        // POST: api/matches/
        [HttpPost]
        public IActionResult UpdateResult([FromBody] MatchModel matchModel)
        {
            var match = _matchesRepository.GetMatch(matchModel.Id);
            if (match != null)
            {
                if (match.Date > DateTime.Now)
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
            var matchModels = MapMatches(_matchesRepository.GetAllMatches());
            return Ok(matchModels);
        }

        private static IEnumerable<MatchModel> MapMatches(ICollection<Match> matches)
        {
            var matchModels = from match in matches
                              select
                                  new MatchModel
                                  {
                                      Id = match.Id,
                                      Date = match.Date,
                                      AwayGoals = match.AwayGoals,
                                      HomeGoals = match.HomeGoals,
                                      HomeTeamFlag = GetFlag(match.HomeTeam),
                                      AwayTeamFlag = GetFlag(match.AwayTeam),
                                      HomeTeam = GetCountry(match.HomeTeam),
                                      AwayTeam = GetCountry(match.AwayTeam),
                                      MatchCompleted = match.Date < DateTime.Now,
                                      Tips = from tip in match.Tips
                                             orderby tip.User
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
                case Country.DE:
                    return "Deutschland";
                case Country.UA:
                    return "Ukraine";
                case Country.PL:
                    return "Polen";
                case Country.NIR:
                    return "Nordirland";

                case Country.EN:
                    return "England";
                case Country.RU:
                    return "Russland";
                case Country.WLS:
                    return "Wales";
                case Country.SK:
                    return "Slowakei";

                case Country.AL:
                    return "Albanien";
                case Country.CH:
                    return "Schweiz";
                case Country.FR:
                    return "Frankreich";
                case Country.RO:
                    return "Rumänien";

                case Country.ES:
                    return "Spanien";
                case Country.CZ:
                    return "Tschechien";
                case Country.TR:
                    return "Türkei";
                case Country.HR:
                    return "Kroatien";

                case Country.BE:
                    return "Belgien";
                case Country.IT:
                    return "Italien";
                case Country.IE:
                    return "Irland";
                case Country.SE:
                    return "Schweden";

                case Country.PT:
                    return "Portugal";
                case Country.IS:
                    return "Island";
                case Country.AT:
                    return "Österreich";
                case Country.HU:
                    return "Ungarn";
                default:
                    return string.Empty;
            }
        }

        private static string GetFlag(Country country)
        {
            switch (country)
            {
                case Country.EN:
                    return "gb-eng";
                case Country.WLS:
                    return "gb-wls";
                case Country.NIR:
                    return "gb-nir";
                default:
                    return country.ToString().ToLower();
            }
        }
    }
}
