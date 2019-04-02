using Microsoft.AspNetCore.Identity;

namespace champi.Domain.Entity.Security
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}