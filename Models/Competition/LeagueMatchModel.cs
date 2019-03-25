using System;
using champi.Libs.Extensions;

namespace champi.Models.Competition
{
    public class LeagueMatchModel
    {
        public long Id { get; set; }
        public long FirstTeamId { get; set; }
        public string FirstTeamName { get; set; }
        public long SecondTeamId { get; set; }
        public string SecondTeamName { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public long? WinnerTeamId { get; set; }
        public string WinnerTeamName { get; set; }
        public DateTime? MatchDate { get; set; }
        public string MatchDatePersian => MatchDate.ConvertToPersianDate();
    }
}