
using bettinggame.data.Entities;
using System.Collections.Generic;

namespace bettinggame.data.Repositories
{
    public interface ITipsRepository
    {

        void AddTips(ICollection<Tip> tips);

        void UpdateTip(long id, int? homeGoals, int? awayGoals);
    }
}
