using System.Data;
using CourgeToujoursAPI.DAL.Entities.Login;
using CourgeToujoursAPI.DAL.Interfaces.Login;
using Dapper;
using Npgsql;

namespace CourgeToujoursAPI.DAL.Repositories.Login;

public class UserRepository:IUserRepository
{
    
    private readonly NpgsqlConnection _connection;

    public UserRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }
    
    
    
    
    //---------------------------------------
    

    public UserB2C CreateUserB2C(UserB2C user)
    {
        try
        {
             
          
            string query = @"
              INSERT INTO ""Utilisateur"" (""nom"" , ""prenom"", ""email"", ""mdp"", ""num_telephone"", ""estAdmin"")
              VALUES (@FirstName,@LastName,@Email,@Password,@phoneNumber,@isAdmin)
              RETURNING 
              ""id_utilisateur"" AS ""IdUser"",
              ""nom"" AS ""FirstName"",
              ""prenom"" AS ""LastName"",
              ""email"" AS ""Email"",
              ""mdp"" AS ""Password"",
              ""num_telephone"" AS ""NumTelephone"",
              ""estAdmin"" AS ""IsAdmin"";
              ";

            UserB2C usercreate = _connection.QueryFirstOrDefault<UserB2C>(query, new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                phoneNumber = user.phoneNumber,
                isAdmin = false
            });
            int userId = usercreate.IdUser;
            
            var B2CQuery = @"
            
                INSERT INTO ""Mangeur_B2C"" (""utilisateur_id"")
                VALUES (@UserId);
            ";
            UserB2C userB2CId = _connection.QueryFirstOrDefault<UserB2C>(B2CQuery, new { UserId = userId});

            
            return usercreate;
            
        }
        catch (Exception e)
        { 
            Console.WriteLine(e);
            throw;
        }

    }

    public UserB2B CreateUserB2B(UserB2B user)
    {
        try
        {
            string queryUser = @"
                INSERT INTO ""Utilisateur"" (""nom"" , ""prenom"", ""email"", ""mdp"", ""num_telephone"",""estAdmin"")
              VALUES (@FirstName,@LastName,@Email,@Password,@phoneNumber,@isAdmin)
              RETURNING 
              ""id_utilisateur"" AS ""IdUser"",
              ""nom"" AS ""FirstName"",
              ""prenom"" AS ""LastName"",
              ""email"" AS ""Email"",
              ""mdp"" AS ""Password"",
              ""num_telephone"" AS ""NumTelephone"",
              ""estAdmin"" AS ""IsAdmin"";


            ";
            UserB2B userB2Bid = _connection.QueryFirstOrDefault<UserB2B>(queryUser, new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                phoneNumber = user.phoneNumber,
                isAdmin = false
            });
            int userID = userB2Bid.IdUser;

            string queryCreateB2B = @"
                INSERT INTO ""Partenaire_B2B"" (""nom_partenaire_B2B"", ""type_partenaire"", ""seuil_livraison"", ""numero_adresse"", ""rue_adresse"", ""ville_adresse"","" code_postal_adresse"", ""utilisateur_id"",""numerodetva"")
                VALUES (@NameCopany,@typeUserB2B,@DeliveryLimit,@NumAdrress,@Street,@City,@userId,@PostalCode ,@TAVNumber)

            ";

            UserB2B B2Bcomplet = _connection.QueryFirstOrDefault<UserB2B>(queryCreateB2B, new
            {
                NameCopany = user.NameCopany,
                typeUserB2B = user.typeUserB2B,
                DeliveryLimit = user.DeliveryLimit,
                NumAdrress = user.NumAdrress,
                Street = user.Street,
                City = user.City,
                userId = userID,
                PostalCode = user.PostalCode,
                TAVNumber = user.TAVNumber
            });
            
            return B2Bcomplet ;




        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}