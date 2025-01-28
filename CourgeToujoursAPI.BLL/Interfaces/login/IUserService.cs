using CourgeToujoursAPI.DAL.Entities.Login;

namespace CourgeToujoursAPI.BLL.Interfaces.login;

public interface IUserService
{
    Task<int> CreateUserB2C(User user);
}