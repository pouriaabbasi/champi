using champi.Domain.Enum;

namespace champi.Models.Competition
{
    public class LeagueResultModel
    {
        public long Id { get; set; }
        public long LeagueId { get; set; }
        public string LeagueName { get; set; }
        public long LeagueTeamId { get; set; }
        public string LeagueTeamName { get; set; }
        public LeagueResultTypeKind LeagueResultType { get; set; }
        public int Rank { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Played { get; set; }
        public int Points { get; set; }
        public int PreviousPosition { get; set; }
    }
}