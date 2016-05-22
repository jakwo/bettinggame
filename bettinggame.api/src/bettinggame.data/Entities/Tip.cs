namespace bettinggame.data.Entities
{
    public class Tip
    {
        public long Id { get; set; }

        public string User { get; set; }

        public int? HomeGoals { get; set; }

        public int? AwayGoals { get; set; }

        public Match Match { get; set; }

        public long MatchId { get; set; }
    }
}
