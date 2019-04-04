using champi.Domain.Base;

namespace champi.Domain.Entity.Security
{
    public class UserToken : BaseEntity
    {
        public long UserId { get; set; }
        public string Token { get; set; }

        public virtual User User { get; set; }
    }
}