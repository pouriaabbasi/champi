using System;
using System.Collections.Generic;
using champi.Domain.Base;
using champi.Domain.Enum;

namespace champi.Domain.Entity.Competition
{
    public class CompetitionStep : BaseEntity
    {
        public long CompetitionId { get; set; }
        public int Step { get; set; }
        public CompetitionTypeKind CompetitionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<League> Leagues { get; set; }
    }
}