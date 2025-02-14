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

    public IEnumerable<UserB2C> GetAllUSerB2C()
    {
            string query = @"

                SELECT u.id_utilisateur AS ""IdUser"",
                       u.nom AS ""FirstName"",
                       u.prenom AS ""LastName"",
                       u.email AS ""Email"" ,
                       u.num_telephone AS ""phoneNumber"",
                       p.id_abonnement AS ""idAbonement""
                FROM ""Utilisateur"" u
                JOIN ""Mangeur_B2C"" p
                ON u.""id_utilisateur"" = p.""utilisateur_id"";";
            
            return _connection.Query<UserB2C>(query);


    }
    
    public UserB2C? GetUSERB2CById(int id)
    {
        string query = @"
                SELECT u.id_utilisateur AS ""IdUser"",
                       u.nom AS ""FirstName"",
                       u.prenom AS ""LastName"",
                       u.email AS ""Email"" ,
                       u.num_telephone AS ""phoneNumber"",
                       p.id_abonnement AS ""idAbonement""
                FROM ""Utilisateur"" u
                JOIN ""Mangeur_B2C"" p
                ON u.""id_utilisateur"" = p.""utilisateur_id""
                WHERE u.id_utilisateur= @idUser;";
        
        return _connection.QueryFirstOrDefault<UserB2C>(query, new { idUser = id });
    }


  

    //B2B//
    
    public IEnumerable<UserB2B> GetAllUSerB2B()
    {
        string query = @"
            SELECT 
                    u.id_utilisateur AS ""IdUser"",
                    u.nom AS ""FirstName"",
                    u.prenom AS ""LastName"",
                    u.email AS ""Email"" ,
                    u.num_telephone AS ""phoneNumber"",
                  
                   p.nom_partenaire_b2b AS ""NameCopany"",
                   p.type_partenaire AS ""typeUserB2B"",
                   p.seuil_livraison AS ""DeliveryLimit"",
                   p.numero_adresse AS ""NumAdrress"",
                   p.rue_adresse AS ""Street"",
                   p.ville_adresse AS ""City"",
                   p.code_postal_adresse AS ""PostalCode"",
                   p.numerodetva AS ""TAVNumber""
            FROM ""Utilisateur"" u
            JOIN ""Partenaire_B2B"" p
            ON u.""id_utilisateur"" = p.""utilisateur_id"";";
        return _connection.Query<UserB2B>(query);
    }

 
    public UserB2B? GetUSERB2BById(int id)
    {
        string query = @"
            SELECT 
                    u.id_utilisateur AS ""IdUser"",
                    u.nom AS ""FirstName"",
                    u.prenom AS ""LastName"",
                    u.email AS ""Email"" ,
                    u.num_telephone AS ""phoneNumber"",
                  
                   p.nom_partenaire_b2b AS ""NameCopany"",
                   p.type_partenaire AS ""typeUserB2B"",
                   p.seuil_livraison AS ""DeliveryLimit"",
                   p.numero_adresse AS ""NumAdrress"",
                   p.rue_adresse AS ""Street"",
                   p.ville_adresse AS ""City"",
                   p.code_postal_adresse AS ""PostalCode"",
                   p.numerodetva AS ""TAVNumber""
            FROM ""Utilisateur"" u
            JOIN ""Partenaire_B2B"" p
            ON u.""id_utilisateur"" = p.""utilisateur_id""
            WHERE u.id_utilisateur= @idUser;";
        
        return _connection.QueryFirstOrDefault<UserB2B>(query, new { idUser = id });
    }

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