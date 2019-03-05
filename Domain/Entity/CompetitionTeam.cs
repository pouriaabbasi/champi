using System.Collections;
using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity
{
    public class CompetitionTeam : BaseEntity
    {
        public long CompetitionId { get; set; }
        public long TeamId { get; set; }

        public Competition Competition { get; set; }
        public Team Team { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }
    }
}