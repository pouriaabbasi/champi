using System;
using System.ComponentModel.DataAnnotations;

namespace champi.Models.Competition
{
    public class UpdateCompetitionModel
    {
        [Required]
        public long GameTypeId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
    }
}