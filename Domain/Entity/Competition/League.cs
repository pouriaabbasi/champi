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
        public int WonPoint { get; set; }
        public int DrawPoint { get; set; }
        public int LostPoint { get; set; }

        public virtual CompetitionStep CompetitionStep { get; set; }

        public virtual ICollection<LeagueTeam> LeagueTeams { get; set; }
        public virtual ICollection<LeagueResult> LeagueResults { get; set; }
        public virtual ICollection<LeagueMatch> LeagueMatches { get; set; }
    }
}