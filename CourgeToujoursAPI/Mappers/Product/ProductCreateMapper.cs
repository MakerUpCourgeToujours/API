using CourgeToujoursAPI.DTOs.Product;
using Model = CourgeToujoursAPI.BLL.Models.Product;

namespace CourgeToujoursAPI.Mappers.Product;

public static class ProductCreateMapper
{

    public static Model.ProductCreate toModel(this ProductCreateDTO prod)
    {
        return new Model.ProductCreate
        {
            id_product = prod.id_product,
            img = prod.img,
            product_description = prod.product_description,
            product_name = prod.product_name,
            product_price = prod.product_price,
            status = prod.status,
            stock_product = prod.stock_product,
            mois_dispos = prod.mois_dispos,
            categoriesList = prod.categoriesList

        };
    }
    
    
    
    
    
}