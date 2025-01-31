using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Mappers.Login;
using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DAL.Interfaces.Login;

using Isopoh.Cryptography.Argon2;

namespace CourgeToujoursAPI.BLL.Services.login;

public class UserService : IUserService
{
    
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    
    public UserB2C CreateUserB2C(UserB2C user)
    {
        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("le mail est requis");
        }
        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ArgumentException("le mot de passe est requis");
        }
        if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
        {
            throw new ArgumentException("votre nom/prenom est requis");
        }
        if (string.IsNullOrEmpty(user.phoneNumber))
        {
            throw new ArgumentException("le numéro de téléphone est requis");
        }
        
        user.Password = Argon2.Hash(user.Password);
        
       return  _userRepository.CreateUserB2C(user.toEntities()).toModel();
    }

    public Models.login.UserB2B CreateUserB2B(Models.login.UserB2B user)
    {
        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("le mail est requis");
        }
        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ArgumentException("le mot de passe est requis");
        }
        if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
        {
            throw new ArgumentException("votre nom/prenom est requis");
        }
        if (string.IsNullOrEmpty(user.phoneNumber))
        {
            throw new ArgumentException("le numéro de téléphone est requis");
        }

        if (string.IsNullOrEmpty(user.City) || string.IsNullOrEmpty(user.Street) ||
            string.IsNullOrEmpty(user.NumAdrress) || string.IsNullOrEmpty(user.PostalCode))
        {
            throw new ArgumentException("l'adress complete est requis");
        }

        if (string.IsNullOrEmpty(user.TAVNumber.ToString()))
        {
            throw new ArgumentException("le numero de TVA est requis");
        }

        if (string.IsNullOrEmpty(user.typeUserB2B) || string.IsNullOrEmpty(user.NameCopany))
        {
            throw new ArgumentException("le nom de la companie  complete est requis");
        }
            
        user.Password = Argon2.Hash(user.Password);
        
        return _userRepository.CreateUserB2B(user.toEntity()).toModel();
    }

    public string Login(User user)
    {
        User userDB = _userRepository.GetByEmail(user.Email).toModelUser();
        
        if(userDB != null && Argon2.Verify(userDB.Password, user.Password))
        {
            return _authService.generateToken(userDB);
        }

        
        throw new Exception("l'email ou passe invalide");
        
        
    }
}