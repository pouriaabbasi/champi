using System;
using champi.Libs.Extensions;

namespace champi.Models.Competition
{
    public class CompetitionModel
    {
        public long Id { get; set; }
        public long GameTypeId { get; set; }
        public string GameTypeName { get; set; }
        public int TeamCount { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDatePersian => StartDate.ConvertToPersianDate();
        public DateTime? EndDate { get; set; }
        public string EndDatePersian => EndDate.ConvertToPersianDate();
    }
}