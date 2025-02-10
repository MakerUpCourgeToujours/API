namespace CourgeToujoursAPI.DTOs.Product;

public class ProductDTO
{
    public int id_product { get; set; }
    public string product_name { get; set; }
    public string product_description { get; set; }
    public decimal product_price { get; set; }
    public string img { get; set; }
    public bool status { get; set; }
    public int stock_product { get; set; }
    
    public string categories { get; set; }
    public string mois_dispo { get; set; } 
    
    public List<string> CategoriesList 
    {
        get => categories?.Split(',').Select(c => c.Trim()).ToList() ?? new List<string>();
    }
    
    public List<string> MoisDispoList 
    {
        get => mois_dispo?.Split(',').Select(m => m.Trim()).ToList() ?? new List<string>();
    }
 
}