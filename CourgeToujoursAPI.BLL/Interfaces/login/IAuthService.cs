using CourgeToujoursAPI.BLL.Models.login;

namespace CourgeToujoursAPI.BLL.Interfaces.login;

public interface IAuthService
{
    public string generateToken(User user);
}