using bettinggame.api.Models;
using bettinggame.data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bettinggame.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class TipsController : Controller
    {
        private ITipsRepository _tipsRepository;
        private IMatchesRepository _matchesRepository;

        public TipsController(ITipsRepository tipsRepository, IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
            _tipsRepository = tipsRepository;
        }

        // POST: api/matches/tips
        [HttpPost]
        public IActionResult UpdateTip([FromBody] TipModel tip)
        {
            var match = _matchesRepository.GetMatch(tip.MatchId);
            if (match != null && match.Date < DateTime.UtcNow)
            {
                return BadRequest("Das Spiel wurde leider schon angepfiffen..");
            }

            _tipsRepository.UpdateTip(tip.Id, tip.HomeGoals, tip.AwayGoals);
            return Ok();
        }
    }
}
