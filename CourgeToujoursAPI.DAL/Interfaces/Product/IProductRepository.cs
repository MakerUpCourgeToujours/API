using CourgeToujoursAPI.DAL.Entities.Product;

namespace CourgeToujoursAPI.DAL.Interfaces.Product;

public interface IProductRepository
{
   public IEnumerable<Produit> GetAllProducts();
    public Produit? GetById(int id);
    
    public int create(ProductCreate produit);
    
    public bool update(ProductCreate produit);
    
    
    
}