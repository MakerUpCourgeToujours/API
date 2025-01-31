using CourgeToujoursAPI.DAL.Entities.Login;

namespace CourgeToujoursAPI.DAL.Interfaces.Login;

public interface IUserRepository
{
    UserB2C CreateUserB2C(UserB2C user);
    
    UserB2B CreateUserB2B(UserB2B user);
    
    User GetByEmail(string email);
    
}