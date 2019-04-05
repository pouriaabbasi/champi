using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using champi.Context.Repository;
using champi.Domain.Entity.Security;
using champi.Libs.Contracts;
using champi.Libs.Helper;
using champi.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace champi.Libs.Implementations
{
    public class UserLib : IUserLib
    {
        private readonly AppSettings appSettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> userRepo;

        public UserLib(
            IOptions<AppSettings> appSettings,
            IUnitOfWork unitOfWork,
            IRepository<User> userRepo
        )
        {
            this.appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
            this.userRepo = userRepo;
        }
        public UserModel Login(LoginModel model)
        {
            var user = userRepo.FirstOrDefault(x =>
                x.Username == model.Username
                && x.Password == model.Password);

            if (user == null) throw new Exception("Username or Password is not valid");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}