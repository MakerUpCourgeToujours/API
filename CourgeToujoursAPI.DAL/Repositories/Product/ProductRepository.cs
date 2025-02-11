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
    
    // get all
    public IEnumerable<Produit> GetAllProducts()
    {
        const string query = @"
SELECT
    p.""id_produit"" AS ""id_product"",
    p.""nom_produit"" AS ""product_name"" ,
    p.""description"" AS ""product_description"",
    p.""prix_unitaire"" AS ""product_price"",
    p.""lien_img"" AS ""img"",
    p.""disponible"" AS ""status"",
    p.""stock_produit"" AS ""stock_product"",
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
    // get by ID 
    public Produit? GetById(int id)
    {
        const string query = @"
SELECT
    p.""id_produit"" AS ""id_product"",
    p.""nom_produit"" AS ""product_name"" ,
    p.""description"" AS ""product_description"",
    p.""prix_unitaire"" AS ""product_price"",
    p.""lien_img"" AS ""img"",
    p.""disponible"" AS ""status"",
    p.""stock_produit"" AS ""stock_product"",
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
//create//
    public int create(ProductCreate produit)
    {
        const string productBase = @"
            INSERT INTO ""Produit"" (nom_produit, description, prix_unitaire,lien_img, disponible,stock_produit)
            VALUES(@product_name , @product_description , @product_price,@img,@status,@stock_product)
            RETURNING id_produit;";
        
        int productId = _connection.QueryFirstOrDefault<int>(productBase, new
        {
            product_name = produit.product_name,
            product_description = produit.product_description,
            product_price = produit.product_price,
            img = produit.img,
            status = produit.status,
            stock_product = produit.stock_product
        });

        if (produit.categoriesList.Any())
        {
            const string AddCategorie = @" 
            INSERT INTO ""Produit_Categorie""(produit_id, categorie_id) 
            VALUES(@id_produit, @id_categorie);";

            foreach (var categoryId in produit.categoriesList)
            {
                _connection.QueryFirstOrDefault<int>(AddCategorie, new
                {
                    id_produit = productId,
                    id_categorie = categoryId
                });
            }
        }

        if (produit.mois_dispos.Any())
        {
            const string AddMonth = @"
            INSERT INTO ""Produit_Mois_Dispo""(produit_id, mois_dispo_id) 
            VALUES(@id_produit, @id_mois_dispos);";

            foreach (var moisDispo in produit.mois_dispos)
            {
                _connection.QueryFirstOrDefault<int>(AddMonth, new
                {
                    id_produit = productId,
                    id_mois_dispos = moisDispo
                });

            }
        }

        return productId;
    }
// update //
    public bool update(ProductCreate produit)
    {
        try
        {
           int productId = produit.id_product;
            const string updateproduit = @"
                UPDATE ""Produit""
                SET ""nom_produit"" = @product_name,
                ""prix_unitaire"" = @product_price,
                ""lien_img"" = @img,
                ""description""= @product_description,
                ""stock_produit""= @stock_product,
                ""disponible""= @status
                WHERE ""id_produit"" = @id_product;
";

            _connection.QueryFirstOrDefault<bool>(updateproduit, new
            {
                product_name = produit.product_name,
                product_price = produit.product_price,
                img = produit.img,
                product_description = produit.product_description,
                stock_product = produit.stock_product,
                status = produit.status,
                id_product = produit.id_product
            });
            
            
                // delete categories for update 
            const string DeleteCategories = @"
            DELETE FROM ""Produit_Categorie"" WHERE produit_id = @id_product;
            ";

            _connection.QueryFirstOrDefault<bool>(DeleteCategories,new { id_product = produit.id_product });
            
            //input new information 

            const string updateCategories = @"
            INSERT INTO ""Produit_Categorie""(produit_id, categorie_id)  VALUES (@id_product,@id_categorie);
            ";

            foreach (var categoryId  in produit.categoriesList)
            {
                _connection.QueryFirstOrDefault<bool>(updateCategories, new
                {
                    id_product = productId,
                    id_categorie = categoryId
                });

            }
            
            
            // delete month for update 
            const string DeleteMonth = @"
            DELETE FROM ""Produit_Mois_Dispo"" WHERE produit_id = @id_product;
            ";

            _connection.QueryFirstOrDefault<bool>(DeleteCategories,new { DeleteMonth = produit.id_product });

            //input new information 

            const string updateMonth = @"
            INSERT INTO ""Produit_Mois_Dispo""(produit_id, mois_dispo_id)  VALUES (@id_product,@mois_dispo_id);
            ";

            foreach (var mois_dispo_id  in produit.mois_dispos)
            {
                _connection.QueryFirstOrDefault<bool>(updateMonth, new
                {
                    id_product = productId,
                    mois_dispo_id = mois_dispo_id
                });

            }
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
            
        }
    }
}