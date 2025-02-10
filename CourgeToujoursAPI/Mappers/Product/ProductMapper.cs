using CourgeToujoursAPI.BLL.Models.Product;
using CourgeToujoursAPI.DTOs.Product;

namespace CourgeToujoursAPI.Mappers.Product;

public static class ProductMapper
{
    public static ProductDTO ToDTO(this Produit product)
    {
        return new ProductDTO
        {
            categories = product.categories,
            id_product = product.id_product,
            img = product.img,
            mois_dispo = product.mois_dispo,
            product_description = product.product_description,
            product_name = product.product_name,
            product_price = product.product_price,
            status = product.status,
            stock_product = product.stock_product,
        };
    }


    public static Produit ToModels(this ProductDTO product)
    {
        return new Produit
        {
            categories = product.categories,
            id_product = product.id_product,
            img = product.img,
            mois_dispo = product.mois_dispo,
            product_description = product.product_description,
            product_name = product.product_name,
            product_price = product.product_price,
            status = product.status,
            stock_product = product.stock_product,

        };
    }
    
    
}
