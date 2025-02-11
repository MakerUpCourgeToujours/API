using CourgeToujoursAPI.BLL.Interfaces.Product;
using CourgeToujoursAPI.BLL.Mappers.Product;
using CourgeToujoursAPI.BLL.Models.Product;
using CourgeToujoursAPI.DAL.Interfaces.Product;

namespace CourgeToujoursAPI.BLL.Services.product;

public class ProductService : IProductService
{
    
    private readonly IProductRepository _ProductRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _ProductRepository = productRepository;
    }
    
    
    public IEnumerable<Produit> GetAllProducts()
    {
        return _ProductRepository.GetAllProducts().Select(p => p.toModel());
    }

    public Produit? GetById(int id)
    {
        Produit product = _ProductRepository.GetById(id).toModel();
        
        if(product == null) return null;
        
        return product;
        
    }

    public int create(ProductCreate produit)
    {
         return  _ProductRepository.create(produit.toEntity());
    }

    public bool update(ProductCreate produit)
    {
       return _ProductRepository.update(produit.toEntity());
    }
}