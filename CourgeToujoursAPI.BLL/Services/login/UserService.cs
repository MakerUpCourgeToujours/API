using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Mappers.Login;
using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DAL.Interfaces.Login;
using Isopoh.Cryptography.Argon2;
using UserB2B = CourgeToujoursAPI.DAL.Entities.Login.UserB2B;

namespace CourgeToujoursAPI.BLL.Services.login;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        
        //TODO la suite est ici pas oublier argon et finir les if 

        return _userRepository.CreateUserB2B(user.toEntity()).toModel();
    }
    
}