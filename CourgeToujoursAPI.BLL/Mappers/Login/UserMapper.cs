﻿using CourgeToujoursAPI.BLL.Models.login;
using Entities = CourgeToujoursAPI.DAL.Entities;
using Models= CourgeToujoursAPI.BLL.Models;


namespace CourgeToujoursAPI.BLL.Mappers.Login;

public static class UserMapper
{
  public static Entities.Login.UserB2C toEntities(this Models.login.UserB2C userB2C)
  {
    return new Entities.Login.UserB2C
    {
      IdUser = userB2C.IdUser,
      Email = userB2C.Email,
      Password = userB2C.Password,
      phoneNumber = userB2C.phoneNumber,
      FirstName = userB2C.FirstName,
      LastName = userB2C.LastName
    };
  }

  public static Models.login.UserB2C toModel(this Entities.Login.UserB2C userB2C)
  {
    return new Models.login.UserB2C
    {
      IdUser = userB2C.IdUser,
      Email = userB2C.Email,
      Password = userB2C.Password,
      phoneNumber = userB2C.phoneNumber,
      FirstName = userB2C.FirstName,
      LastName = userB2C.LastName
      
    };
  }


  public static Entities.Login.UserB2B toEntity(this Models.login.UserB2B user)
  {
    return new Entities.Login.UserB2B
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
  
  
  public static Models.login.UserB2B toModel(this Entities.Login.UserB2B user)
  {
    return new Models.login.UserB2B
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


  public static Entities.Login.User toEntitiesUser(this Models.login.User user)
  {
    return new Entities.Login.User
    {
      IdUser = user.IdUser,
      Email = user.Email,
      Password = user.Password,
      phoneNumber = user.phoneNumber,
      FirstName = user.FirstName,
      LastName = user.LastName,
      isAdmin = user.isAdmin,
      isB2C = user.isB2c
    };
  }

  public static Models.login.User toModelUser(this Entities.Login.User user)
  {
    return new Models.login.User
    {
      IdUser = user.IdUser,
      Email = user.Email,
      Password = user.Password,
      phoneNumber = user.phoneNumber,
      FirstName = user.FirstName,
      LastName = user.LastName,
      isAdmin = user.isAdmin,
      isB2c = user.isB2C
    };
  }
 
  
  
  
  
}