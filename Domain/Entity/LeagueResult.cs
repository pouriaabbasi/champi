using champi.Domain.Base;
using champi.Domain.Enum;

namespace champi.Domain.Entity
{
    public class LeagueResult : BaseEntity
    {
        public long LeagueId { get; set; }
        public long LeagueTeamId { get; set; }
        public LeagueResultTypeKind LeagueResultType { get; set; }
        public int Rank { get; set; }

        public League League { get; set; }
        public LeagueTeam LeagueTeam { get; set; }
    }
}