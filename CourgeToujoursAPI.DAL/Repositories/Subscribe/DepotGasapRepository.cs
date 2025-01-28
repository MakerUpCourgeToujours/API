using CourgeToujoursAPI.DAL.Entities.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;
using Dapper;
using Npgsql;

namespace CourgeToujoursAPI.DAL.Repositories.Subscribe;

public class DepotGasapRepository : IDepotGasapRepository
{
    private readonly NpgsqlConnection _connection;
    
    public DepotGasapRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<DepotGasap> GetAll()
    {
        const string query = @"
            SELECT
                ""id_depot_gasap"" AS ""IdGasap"",
                ""adresse"" AS ""Address"",
                ""jour_livraison"" AS ""DeliveryDay"",
                ""nom_depot"" AS ""DepotName"" ,
                ""frequence"" AS ""Frequency"",
                ""contact"" AS ""Mail""
            FROM ""Depot_gasap""
        ";
        return _connection.Query<DepotGasap>(query);
    }
}