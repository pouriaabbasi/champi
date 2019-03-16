namespace champi.Models.Competition
{
    public class CompetitionTeamModel
    {
        public long Id { get; set; }
        public long CompetitionId { get; set; }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
    }
}