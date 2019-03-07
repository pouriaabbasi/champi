using System.ComponentModel.DataAnnotations;

namespace champi.Models.Team
{
    public class AddTeamModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string AbbreviationName { get; set; }
        public string Logo { get; set; }
    }
}