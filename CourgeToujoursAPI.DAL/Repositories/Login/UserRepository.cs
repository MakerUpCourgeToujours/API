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
              INSERT INTO ""Utilisateur"" (nom , prenom, email, mdp, num_telephone, estAdmin,estb2c)
              VALUES (@FirstName,@LastName,@Email,@Password,@phoneNumber,@isAdmin,@IsB2C)
              RETURNING 
              id_utilisateur AS ""IdUser"",
              nom AS ""FirstName"",
              prenom AS ""LastName"",
              email AS ""Email"",
              num_telephone AS ""NumTelephone"",
              estAdmin AS ""IsAdmin"",
              estb2c AS ""IsB2C""
              ;
              ";

            UserB2C usercreate = _connection.QueryFirstOrDefault<UserB2C>(query, new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                phoneNumber = user.phoneNumber,
                IsAdmin = false,
                IsB2C = true
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

                                                            //B2B//
    
    public UserB2B CreateUserB2B(UserB2B user)
    {
        try
        {
            string query = @"
              INSERT INTO ""Utilisateur"" (nom , prenom, email, mdp, num_telephone, estAdmin,estb2c)
              VALUES (@FirstName,@LastName,@Email,@Password,@phoneNumber,@isAdmin,@IsB2C)
              RETURNING 
              id_utilisateur AS ""IdUser"",
              nom AS ""FirstName"",
              prenom AS ""LastName"",
              email AS ""Email"",
              num_telephone AS ""NumTelephone"",
              estAdmin AS ""IsAdmin"",
              estb2c AS ""IsB2C""; ";
            UserB2C usercreate = _connection.QueryFirstOrDefault<UserB2C>(query, new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                phoneNumber = user.phoneNumber,
                IsAdmin = false,
                IsB2C = false
            });
            int userID = usercreate.IdUser;

            string queryCreateB2B = @"
                
                INSERT INTO ""Partenaire_B2B""(nom_partenaire_b2b, type_partenaire, seuil_livraison, numero_adresse, rue_adresse, ville_adresse, code_postal_adresse,utilisateur_id, numerodetva)
                VALUES (@NameCopany,@typeUserB2B,@DeliveryLimit,@NumAdrress,@Street,@City,@PostalCode,@userID,@TAVNumber)
                RETURNING
                nom_partenaire_b2b AS ""NameCopany"",
                type_partenaire AS ""TypeUserB2B"", 
                seuil_livraison AS ""DeliveryLimit"",
                numero_adresse AS ""NumAdrress"", 
                rue_adresse AS ""Street"", 
                ville_adresse AS ""City"", 
                code_postal_adresse  AS ""PostalCode"", 
                utilisateur_id AS ""userID"" ,
                numerodetva AS ""TAVNumber"";

                
            ";

            UserB2B B2Bcomplet = _connection.QueryFirstOrDefault<UserB2B>(queryCreateB2B, new
            {
                NameCopany = user.NameCopany,
                typeUserB2B = user.typeUserB2B,
                DeliveryLimit = user.DeliveryLimit,
                NumAdrress = user.NumAdrress,
                Street = user.Street,
                City = user.City,
                PostalCode = user.PostalCode,
                userId = userID,
                TAVNumber = user.TAVNumber,
            });
            
            return B2Bcomplet ;




        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    // GET EMAIL FOR LOGIN CHECK //
    public User? GetByEmail(string email)
    {
        const string query = @"
            SELECT
                id_utilisateur AS ""IdUser"",
                nom AS ""FirstName"",
                prenom AS ""LastName"", 
                email AS ""Email"",
                mdp AS ""Password"",
                estAdmin AS ""isAdmin"",
                estb2c AS ""isB2C""
            FROM ""Utilisateur""
            WHERE email = @Email;
            
        ";
        return _connection.QuerySingleOrDefault<User>(query, new { Email = email });
    }
}