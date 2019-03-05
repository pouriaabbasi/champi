using champi.Domain.Base;

namespace champi.Domain.Entity
{
    public class LeagueTeam : BaseEntity
    {
        public long LeagueId { get; set; }
        public long CompetitionTeamId { get; set; }

        public League League { get; set; }
        public CompetitionTeam CompetitionTeam { get; set; }
    }
}