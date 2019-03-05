using System;

namespace champi.Domain.Base
{
    public class Competition : BaseEntity
    {
        public string Name { get; set; }
        public int Iteration { get; set; }
        public int TeamCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public long? ChampionTeamId { get; set; }

        // public Team ChampionTeam { get; set; }
    }
}