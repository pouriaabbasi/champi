using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class League : BaseEntity
    {
        public long CompetitionStepId { get; set; }
        public int TeamCount { get; set; }
        public bool IsHomeAway { get; set; }
        public int PeerToPeerPlayCount { get; set; }
        public int RiseTeamCount { get; set; }
        public int FallTeamCount { get; set; }

        public CompetitionStep CompetitionStep { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }
        public ICollection<LeagueResult> LeagueResults { get; set; }
    }
}