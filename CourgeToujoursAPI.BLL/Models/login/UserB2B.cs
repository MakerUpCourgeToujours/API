﻿namespace CourgeToujoursAPI.BLL.Models.login;

public class UserB2B : User
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