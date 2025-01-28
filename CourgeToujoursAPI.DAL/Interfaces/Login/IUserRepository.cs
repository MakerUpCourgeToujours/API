using CourgeToujoursAPI.DAL.Entities.Login;

namespace CourgeToujoursAPI.DAL.Interfaces.Login;

public interface IUserRepository
{
    Task<int> CreateUserB2C(UserB2C user);
    
}