using System;
using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class Competition : BaseEntity
    {
        public long GameTypeId { get; set; }
        public string Name { get; set; }
        public int Iteration { get; set; }
        public int TeamCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public long? ChampionTeamId { get; set; }

        public Team ChampionTeam { get; set; }
        public GameType GameType {get;set;}

        public ICollection<CompetitionStep> CompetitionSteps { get; set; }
        public ICollection<CompetitionTeam> CompetitionTeams { get; set; }
    }
}