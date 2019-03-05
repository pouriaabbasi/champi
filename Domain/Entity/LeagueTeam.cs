using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity
{
    public class LeagueTeam : BaseEntity
    {
        public long LeagueId { get; set; }
        public long CompetitionTeamId { get; set; }

        public League League { get; set; }
        public CompetitionTeam CompetitionTeam { get; set; }

        public ICollection<LeagueMatch> LeagueMatchesFirstTeam { get; set; }
        public ICollection<LeagueMatch> LeagueMatchesSecondTeam { get; set; }
        public ICollection<LeagueMatch> LeagueMatchesWinnerTeam { get; set; }
        public ICollection<LeagueResult> LeagueResults { get; set; }
    }
}