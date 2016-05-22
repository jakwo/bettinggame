using bettinggame.data.Entities;
using System.Collections.Generic;

namespace bettinggame.data.Repositories
{
    public interface IMatchesRepository
    {
        ICollection<Match> GetAllMatches();

        void UpdateMatchResult(long id, int? homeGoals, int? awayGoals);
    }
}
