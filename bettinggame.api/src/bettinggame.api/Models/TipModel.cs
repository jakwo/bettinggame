namespace bettinggame.api.Models
{
    public class TipModel
    {
        public long Id { get; set; }

        public long MatchId { get; set; }

        public string User { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }
    }
}
