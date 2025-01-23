using CourgeToujoursAPI.DAL.Entities.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;
using Dapper;
using Npgsql;

namespace CourgeToujoursAPI.DAL.Repositories.Subscribe;

public class SubTypeRepository : ISubTypeRepository
{
    private readonly NpgsqlConnection _connection;

    public SubTypeRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }
    
    public SubType GetSubTypeById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<SubType> GetAll()
    {
        const string query = @"
        SELECT
       at.""id_abonnement"" AS ""IdSub"",
       at.""nom_abonnement"" AS ""NameSub"",
       at.""prix_an_abonnement"" AS ""PriceSub"" ,
       tp.""taille"" AS ""Size"",
       tp.""nombre_personne"" AS ""NumberPeople"",
       tfl.""nombre_panier_total"" AS ""TotalBasket"",
       tfl.""frequence_livraison"" AS ""DeliveryTime""
       FROM ""Abonnement_Type""  at
       JOIN ""Taille_Panier""  tp on at.panier_id = tp.id_panier
       JOIN ""Type_Frequence_Livraison""  tfl ON at.type_frequence_livraison_id = tfl.id_type_frequence_livraison
       ORDER BY at.""id_abonnement"" ";
        
       return _connection.Query<SubType>(query);
    }
}