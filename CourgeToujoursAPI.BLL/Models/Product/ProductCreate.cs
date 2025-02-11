namespace CourgeToujoursAPI.BLL.Models.Product;

public class ProductCreate
{
    public int id_product { get; set; }
    public string product_name { get; set; }
    public string product_description { get; set; }
    public decimal product_price { get; set; }
    public string img { get; set; }
    public bool status { get; set; }
    public int stock_product { get; set; }
    
    public List<int> categoriesList { get; set; }
    public List<int> mois_dispos { get; set; } 
}