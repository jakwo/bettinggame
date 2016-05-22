using System;
using System.Collections.Generic;
using bettinggame.data.Entities;
using System.Linq;

namespace bettinggame.data.Repositories
{
    public class TipsRepository : ITipsRepository
    {
        BettingGameContext _context;

        public TipsRepository(BettingGameContext context)
        {
            _context = context;
        }

        public void AddTips(ICollection<Tip> tips)
        {
            _context.Tips.AddRange(tips);
            _context.SaveChanges();
        }

        public void UpdateTip(long id, int? homeGoals, int? awayGoals)
        {
            var tip = _context.Tips.FirstOrDefault(x => x.Id == id);
            if (tip != null)
            {
                tip.AwayGoals = awayGoals;
                tip.HomeGoals = homeGoals;

                _context.Tips.Update(tip);
                _context.SaveChanges();
            }
        }
    }
}
