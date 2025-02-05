using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Models.login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CourgeToujoursAPI.BLL.Services.login;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config)
    {
        _config = config;
    }
    public string generateToken(User user)
    {
        
        List<Claim> claims = new List<Claim>()
        {
            
            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim("lastname", user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        if (user.isAdmin == true)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }
        else if (user.isB2c == true)
        {
            claims.Add(new Claim(ClaimTypes.Role, "B2C"));
        }
        else if (user.isB2c == false)
        {
            claims.Add(new Claim(ClaimTypes.Role, "B2B"));
        }
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}