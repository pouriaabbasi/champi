using champi.Domain.Base;
using champi.Domain.Enum;

namespace champi.Domain.Entity.Competition
{
    public class LeagueResult : BaseEntity
    {
        public long LeagueId { get; set; }
        public long LeagueTeamId { get; set; }
        public LeagueResultTypeKind LeagueResultType { get; set; }
        public int Rank { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public int PreviousPosition { get; set; }

        public virtual League League { get; set; }
        public virtual LeagueTeam LeagueTeam { get; set; }
    }
}