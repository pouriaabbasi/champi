using champi.Models.User;

namespace champi.Libs.Contracts
{
    public interface IUserLib
    {
        UserModel Login(LoginModel model);
    }
}