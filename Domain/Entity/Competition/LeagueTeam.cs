using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class LeagueTeam : BaseEntity
    {
        public long LeagueId { get; set; }
        public long CompetitionTeamId { get; set; }

        public virtual League League { get; set; }
        public virtual CompetitionTeam CompetitionTeam { get; set; }

        public virtual ICollection<LeagueMatch> LeagueMatchesFirstTeam { get; set; }
        public virtual ICollection<LeagueMatch> LeagueMatchesSecondTeam { get; set; }
        public virtual ICollection<LeagueMatch> LeagueMatchesWinnerTeam { get; set; }
        public virtual ICollection<LeagueResult> LeagueResults { get; set; }
    }
}