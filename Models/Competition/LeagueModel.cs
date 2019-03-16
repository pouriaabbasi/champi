namespace champi.Models.Competition
{
    public class LeagueModel
    {
        public long Id { get; set; }
        public long CompetitionStepId { get; set; }
        public int TeamCount { get; set; }
        public bool IsHomeAway { get; set; }
        public int PeerToPeerPlayCount { get; set; }
        public int RiseTeamCount { get; set; }
        public int FallTeamCount { get; set; }
    }
}