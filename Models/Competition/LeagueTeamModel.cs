namespace champi.Models.Competition
{
    public class LeagueTeamModel
    {
        public long Id { get; set; }
        public long CompetitionTeamId { get; set; }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
    }
}