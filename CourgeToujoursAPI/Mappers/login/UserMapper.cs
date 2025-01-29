using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DTOs.Login;

namespace CourgeToujoursAPI.Mappers;

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
    
    
    
    
    
    
}