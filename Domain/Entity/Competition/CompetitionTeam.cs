using System.Collections;
using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class CompetitionTeam : BaseEntity
    {
        public long CompetitionId { get; set; }
        public long TeamId { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<LeagueTeam> LeagueTeams { get; set; }
    }
}