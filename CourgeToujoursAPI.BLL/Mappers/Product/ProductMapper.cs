using  CourgeToujoursAPI.BLL.Models.Product;
using Entities = CourgeToujoursAPI.DAL.Entities;
using ProductCreate = CourgeToujoursAPI.DAL.Entities.Product.ProductCreate;

namespace CourgeToujoursAPI.BLL.Mappers.Product;

public static class ProductMapper
{

    public static Entities.Product.Produit toEntity(this Produit product)
    {
        return new Entities.Product.Produit
        {
            id_product = product.id_product,
            categories = product.categories,
            mois_dispo = product.mois_dispo,
            img = product.img,
            product_description = product.product_description,
            product_name = product.product_name,
            product_price = product.product_price,
            status = product.status,
            stock_product = product.stock_product,
            
        };
    }

    public static Produit toModel(this Entities.Product.Produit product)
    {
        return new Produit
        {
            id_product = product.id_product,
            categories = product.categories,
            mois_dispo = product.mois_dispo,
            img = product.img,
            product_description = product.product_description,
            product_name = product.product_name,
            product_price = product.product_price,
            status = product.status,
            stock_product = product.stock_product

        };
    }
    

    
    
    
}