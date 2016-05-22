using System;
using System.Collections.Generic;

namespace bettinggame.api.Models
{
    public class MatchModel
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string HomeTeamFlag { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeamFlag { get; set; }

        public string AwayTeam { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public bool MatchCompleted { get; set; }

        public IEnumerable<TipModel> Tips { get; set; }
    }
}
