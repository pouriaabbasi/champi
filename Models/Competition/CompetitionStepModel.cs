using System;
using champi.Domain.Enum;
using champi.Libs.Extensions;

namespace champi.Models.Competition
{
    public class CompetitionStepModel
    {
        public long Id { get; set; }
        public long CompetitionId { get; set; }
        public int Step { get; set; }
        public CompetitionTypeKind CompetitionType { get; set; }
        public string CompetitionTypeString { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDatePersian => StartDate.ConvertToPersianDate();
        public DateTime? EndDate { get; set; }
        public string EndDatePersian => EndDate.ConvertToPersianDate();
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
    }
}