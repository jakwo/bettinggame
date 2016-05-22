using bettinggame.api.Models;
using bettinggame.data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bettinggame.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class TipsController
    {
        private ITipsRepository _tipsRepository;

        public TipsController(ITipsRepository tipsRepository)
        {
            _tipsRepository = tipsRepository;
        }

        // POST: api/matches/tips
        [HttpPost]
        public void UpdateTip([FromBody] TipModel tip)
        {
            _tipsRepository.UpdateTip(tip.Id, tip.HomeGoals, tip.AwayGoals);
        }
    }
}
