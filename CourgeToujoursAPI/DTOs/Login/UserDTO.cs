using System.ComponentModel.DataAnnotations;

namespace CourgeToujoursAPI.DTOs.Login;

public class UserDTO
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string phoneNumber { get; set; }
    public bool isAdmin { get; set; }
}


public class LoginUserDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}