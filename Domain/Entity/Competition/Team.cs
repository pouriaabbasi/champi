using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string AbbreviationName { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Competition> ChampionCompetitions { get; set; }
        public virtual ICollection<CompetitionTeam> CompetitionTeams { get; set; }
    }
}