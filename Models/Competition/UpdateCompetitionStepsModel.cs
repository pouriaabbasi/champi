using System;
using champi.Domain.Enum;

namespace champi.Models.Competition
{
    public class UpdateCompetitionStepsModel
    {
        public CompetitionTypeKind CompetitionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }

    }
}