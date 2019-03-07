using System;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class LeagueMatch : BaseEntity
    {
        public long FirstTeamId { get; set; }
        public long SecondTeamId { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public long? WinnerTeamId { get; set; }
        public DateTime? MatchDate { get; set; }

        public LeagueTeam FirstTeam { get; set; }
        public LeagueTeam SecondTeam { get; set; }
        public LeagueTeam WinnerTeam { get; set; }
    }
}