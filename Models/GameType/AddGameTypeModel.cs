using System.ComponentModel.DataAnnotations;

namespace champi.Models.GameType
{
    public class AddGameTypeModel
    {
        [Required]
        public string Name { get; set; }
        public long? ParentGameTypeId { get; set; }
    }
}