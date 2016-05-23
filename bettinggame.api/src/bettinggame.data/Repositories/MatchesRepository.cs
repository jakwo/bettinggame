using System;
using System.Collections.Generic;
using System.Linq;
using bettinggame.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace bettinggame.data.Repositories
{
    public class MatchesRepository : IMatchesRepository
    {
        BettingGameContext _context;

        public MatchesRepository(BettingGameContext bettingGameContext)
        {
            _context = bettingGameContext;
        }

        public ICollection<Match> GetAllMatches()
        {
            return _context.Matches
                .Include(x => x.Tips)
                .OrderBy(x => x.Date).ToList();
        }

        public Match GetMatch(long id)
        {
            return _context.Matches.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMatchResult(long id, int? homeGoals, int? awayGoals)
        {
            var match = _context.Matches.FirstOrDefault(x => x.Id == id);
            if (match != null)
            {
                match.AwayGoals = awayGoals;
                match.HomeGoals = homeGoals;

                _context.Matches.Update(match);
                _context.SaveChanges();
            }
        }
    }
}
