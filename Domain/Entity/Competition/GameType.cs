using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity.Competition
{
    public class GameType : BaseEntity
    {
        public string Name { get; set; }
        public long? ParentGameTypeId { get; set; }

        public virtual GameType ParentGameType { get; set; }

        public virtual ICollection<GameType> ChildGameTypes { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
    }
}