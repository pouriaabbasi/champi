using System.Collections.Generic;
using champi.Domain.Base;
using Microsoft.AspNetCore.Identity;

namespace champi.Domain.Entity.Security
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}