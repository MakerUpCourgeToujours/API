using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.DAL.Entities.Login;
using CourgeToujoursAPI.DAL.Interfaces.Login;

namespace CourgeToujoursAPI.BLL.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public Task<int> CreateUserB2C(User user)
    {
        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("le mail est requis");
        }
        if (string.IsNullOrEmpty(user.Password))
        
            //TODO finir ici !!!
       return await _userRepository.CreateUserB2C(user);
    }
}