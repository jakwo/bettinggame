using System;
using System.Collections.Generic;

namespace bettinggame.data.Entities
{
    public class Match
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public Country HomeTeam { get; set; }

        public Country AwayTeam { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public virtual ICollection<Tip> Tips { get; set; }
    }
}
