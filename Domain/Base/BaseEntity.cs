using System.ComponentModel.DataAnnotations;

namespace champi.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}