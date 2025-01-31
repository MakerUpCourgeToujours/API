namespace CourgeToujoursAPI.DAL.Entities.Login;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string phoneNumber { get; set; }
    
    public bool isAdmin { get; set; }
    
    public bool isB2C { get; set; }
}