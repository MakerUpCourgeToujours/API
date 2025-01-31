

using CourgeToujoursAPI.BLL.Models.login;


namespace CourgeToujoursAPI.BLL.Interfaces.login;

public interface IUserService
{
    UserB2C CreateUserB2C(UserB2C user);
    
    UserB2B CreateUserB2B(UserB2B user);
    
    string Login(User user);
}