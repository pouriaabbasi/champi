namespace champi.Models.Dashboard
{
    public class StatisticsModel
    {
        public int UserCount { get; set; }
        public int TeamCount { get; set; }
        public int GameTypeCount { get; set; }
        public int LeagueCount { get; set; }
        public ChartModel LeaguePerMonthData { get; set; }
        public ChartModel LeagueByLeagueTypeData { get; set; }
    }
}