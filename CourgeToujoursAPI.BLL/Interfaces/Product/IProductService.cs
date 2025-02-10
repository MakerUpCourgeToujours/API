using CourgeToujoursAPI.BLL.Models.Product;

namespace CourgeToujoursAPI.BLL.Interfaces.Product;

public interface IProductService
{
    public IEnumerable<Produit> GetAllProducts();
    public Produit? GetById(int id);
    public int create(Produit produit);
    public bool update(Produit produit);
}