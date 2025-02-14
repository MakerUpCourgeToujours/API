using CourgeToujoursAPI.DAL.Entities.Login;

namespace CourgeToujoursAPI.DAL.Interfaces.Login;

public interface IUserRepository
{
    UserB2C CreateUserB2C(UserB2C user);
    
    public IEnumerable<UserB2C> GetAllUSerB2C();
    
    public IEnumerable<UserB2B> GetAllUSerB2B();
    
    
    public UserB2C? GetUSERB2CById(int id);
    
    public UserB2B? GetUSERB2BById(int id);
    
    UserB2B CreateUserB2B(UserB2B user);
    
    User GetByEmail(string email);
    
    
    
    
    
}