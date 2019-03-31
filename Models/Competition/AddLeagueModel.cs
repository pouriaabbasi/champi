using System.Collections.Generic;

namespace champi.Models.Competition
{
    public class AddLeagueModel
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
        public List<AddLeagueTeamModel> LeagueTeams { get; set; }
    }
}