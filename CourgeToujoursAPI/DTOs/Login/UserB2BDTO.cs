namespace CourgeToujoursAPI.DTOs.Login;

public class UserB2BDTO: UserDTO
{
    
   
    public string NameCopany { get; set; }
   
    public string typeUserB2B { get; set; }
   
    public int DeliveryLimit {get; set;}
   
    public string NumAdrress { get; set; }
   
    public string Street { get; set; }
   
    public string City { get; set; }
   
    public string PostalCode { get; set; }
   
    public string TAVNumber { get; set; }
}