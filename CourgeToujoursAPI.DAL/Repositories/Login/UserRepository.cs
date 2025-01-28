using System.Data;
using CourgeToujoursAPI.DAL.Entities.Login;
using CourgeToujoursAPI.DAL.Interfaces.Login;
using Dapper;
using Npgsql;

namespace CourgeToujoursAPI.DAL.Repositories;

public class UserRepository:IUserRepository
{
    
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    
    
    
    //---------------------------------------
    

    public async Task<int> CreateUserB2C(UserB2C user)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        
        using var transaction = await connection.BeginTransactionAsync();
        try
        {
            var userQuery = @"
              INSERT INTO ""Utilisateur"" (""nom"" , prenom, email, mdp, num_telephone, ""estAdmin"")
              VALUES (@FirstName,@LastName,@Email,@Password,@phoneNumber,@isAdmin)
              RETURNING ""id_utilisateur"";
              ";

            var userId = await connection.QuerySingleAsync<int>(userQuery, new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.phoneNumber,
                user.isAdmin
            });

            var B2CQuery = @"
               
                INSERT INTO ""Mangeur_B2C"" (""utilisateur_id"")
                VALUES (@UserId);
            ";

            await connection.ExecuteAsync(B2CQuery, new
            {
                UserId = userId
            });
            
            await transaction.CommitAsync();
            return userId;
            
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }

    }
}