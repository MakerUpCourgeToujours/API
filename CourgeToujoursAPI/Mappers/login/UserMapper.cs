using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DTOs.Login;

namespace CourgeToujoursAPI.Mappers.login;

public static class UserMapper
{
    public static UserB2CDTO toDTO(this UserB2C userB2C)
    {
        return new UserB2CDTO()
        {
            Email = userB2C.Email,
            Password = userB2C.Password,
            phoneNumber = userB2C.phoneNumber,
            FirstName = userB2C.FirstName,
            LastName = userB2C.LastName,
            IdUser = userB2C.IdUser,
        };
    }

    public static UserB2C toModel(this UserB2CDTO userB2CDTO)
    {
        return new UserB2C()
        {
            Email = userB2CDTO.Email,
            Password = userB2CDTO.Password,
            phoneNumber = userB2CDTO.phoneNumber,
            FirstName = userB2CDTO.FirstName,
            LastName = userB2CDTO.LastName,
            IdUser = userB2CDTO.IdUser,
        };

    }

    public static UserB2BDTO ToDto(this UserB2B user)
    {
        return new UserB2BDTO()
        {
            IdUser = user.IdUser,
            Email = user.Email,
            Password = user.Password,
            phoneNumber = user.phoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            
            NameCopany = user.NameCopany,
            typeUserB2B = user.typeUserB2B,
            City = user.City,
            NumAdrress = user.NumAdrress,
            Street = user.Street,
            PostalCode = user.PostalCode,
            DeliveryLimit = user.DeliveryLimit,
            TAVNumber = user.TAVNumber,
            
        };
    }
    
    public static UserB2B ToModel(this UserB2BDTO user)
    {
        return new UserB2B()
        {
            IdUser = user.IdUser,
            Email = user.Email,
            Password = user.Password,
            phoneNumber = user.phoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            
            NameCopany = user.NameCopany,
            typeUserB2B = user.typeUserB2B,
            City = user.City,
            NumAdrress = user.NumAdrress,
            Street = user.Street,
            PostalCode = user.PostalCode,
            DeliveryLimit = user.DeliveryLimit,
            TAVNumber = user.TAVNumber,

        };
    }
    
    
    
    
    public static User ToModelsLogin(this LoginUserDTO user)
    {
        return new User
        {
            Email = user.Email,
            Password = user.Password,
        }; 
    }
    
    
}