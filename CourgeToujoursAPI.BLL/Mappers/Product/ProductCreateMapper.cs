using CourgeToujoursAPI.BLL.Models.Product;
using  Entities = CourgeToujoursAPI.DAL.Entities.Product;

namespace CourgeToujoursAPI.BLL.Mappers.Product;

public static class ProductCreateMapper
{
    public static Entities.ProductCreate toEntity(this ProductCreate prod)
    {
        return new Entities.ProductCreate
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


    public static ProductCreate toModel( this Entities.ProductCreate prod)
    {
        return new ProductCreate{
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