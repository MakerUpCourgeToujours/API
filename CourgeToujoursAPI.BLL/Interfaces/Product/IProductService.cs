using CourgeToujoursAPI.BLL.Models.Product;

namespace CourgeToujoursAPI.BLL.Interfaces.Product;

public interface IProductService
{
    public IEnumerable<Produit> GetAllProducts();
    public Produit? GetById(int id);
    public int create(ProductCreate produit);
    public bool update(ProductCreate produit);
}