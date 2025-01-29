namespace CourgeToujoursAPI.BLL.Models.login;

public class UserB2B : User
{
    public int Id_UserB2B { get; set; }
   
    public string NameCopany { get; set; }
   
    public string typeUserB2B { get; set; }
   
    public int DeliveryLimit {get; set;}
   
    public string NumAdrress { get; set; }
   
    public string Street { get; set; }
   
    public string City { get; set; }
   
    public string PostalCode { get; set; }
   
    public int UserId { get; set; }
   
    public int TAVNumber { get; set; } 
}