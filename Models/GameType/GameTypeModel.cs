namespace champi.Models.GameType
{
    public class GameTypeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentGameTypeId { get; set; }
    }
}