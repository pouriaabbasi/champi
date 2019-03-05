using System.Collections.Generic;
using champi.Domain.Base;

namespace champi.Domain.Entity
{
    public class GameType : BaseEntity
    {
        public string Name { get; set; }
        public long? ParentGameTypeId { get; set; }

        public GameType ParentGameType { get; set; }

        public ICollection<GameType> ChildGameTypes { get; set; }
    }
}