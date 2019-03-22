using System.Collections.Generic;

namespace champi.Models.Competition
{
    public class UpdateLeagueModel
    {
        public int TeamCount { get; set; }
        public bool IsHomeAway { get; set; }
        public int PeerToPeerPlayCount { get; set; }
        public int RiseTeamCount { get; set; }
        public int FallTeamCount { get; set; }
        public List<UpdateLeagueTeamModel> LeagueTeams { get; set; }
    }
}