using CourgeToujoursAPI.DAL.Entities.Product;
using CourgeToujoursAPI.DAL.Interfaces.Product;
using Dapper;
using Npgsql;

namespace CourgeToujoursAPI.DAL.Repositories.Product;

public class ProductRepository : IProductRepository
{
    
    private readonly NpgsqlConnection _connection;
    
    public ProductRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }
    
    
    public IEnumerable<Produit> GetAllProducts()
    {
        const string query = @"
SELECT
    p.""id_produit"",
    p.""nom_produit"",
    p.""description"",
    p.""prix_unitaire"",
    p.""lien_img"",
    p.""disponible"",
    COALESCE(c.""categories"", '') AS ""categories"",
    COALESCE(m.""mois_dispo"", '') AS ""mois_dispo""
FROM
    ""Produit"" p
LEFT JOIN (
    SELECT
        pc.""produit_id"",
        string_agg(c.""nom_categorie"", ', ') AS ""categories""
    FROM
        ""Produit_Categorie"" pc
    JOIN
        ""Categorie"" c ON pc.""categorie_id"" = c.""id_categorie""
    GROUP BY
        pc.""produit_id""
) c ON p.""id_produit"" = c.""produit_id""
LEFT JOIN (
    SELECT
        pmd.""produit_id"",
        string_agg(m.""nom_mois"", ', ') AS ""mois_dispo""
    FROM
        ""Produit_Mois_Dispo"" pmd
    JOIN
        ""Mois_Dispo"" m ON pmd.""mois_dispo_id"" = m.""id_mois_dispo""
    GROUP BY
        pmd.""produit_id""
) m ON p.""id_produit"" = m.""produit_id"";

";
        return _connection.Query<Produit>(query);
    }

    public Produit? GetById(int id)
    {
        const string query = @"
SELECT
    p.""id_produit"",
    p.""nom_produit"",
    p.""description"",
    p.""prix_unitaire"",
    p.""lien_img"",
    p.""disponible"",
    COALESCE(c.""categories"", '') AS ""categories"",
    COALESCE(m.""mois_dispo"", '') AS ""mois_dispo""
FROM
    ""Produit"" p
LEFT JOIN (
    SELECT
        pc.""produit_id"",
        string_agg(c.""nom_categorie"", ', ') AS ""categories""
    FROM
        ""Produit_Categorie"" pc
    JOIN
        ""Categorie"" c ON pc.""categorie_id"" = c.""id_categorie""
    GROUP BY
        pc.""produit_id""
) c ON p.""id_produit"" = c.""produit_id""
LEFT JOIN (
    SELECT
        pmd.""produit_id"",
        string_agg(m.""nom_mois"", ', ') AS ""mois_dispo""
    FROM
        ""Produit_Mois_Dispo"" pmd
    JOIN
        ""Mois_Dispo"" m ON pmd.""mois_dispo_id"" = m.""id_mois_dispo""
    GROUP BY
        pmd.""produit_id""
) m ON p.""id_produit"" = m.""produit_id""
WHERE id_produit = @idProduct;
";
        return _connection.QueryFirstOrDefault<Produit>(query, new { idProduct = id });
        
    }

    public int create(Produit produit)
    {
        throw new NotImplementedException();
    }

    public bool update(Produit produit)
    {
        throw new NotImplementedException();
    }
}