namespace CourgeToujoursAPI.DAL.Entities.Subscribe;

public class SubType
{
    public int IdSub { get; set; }
    public string NameSub { get; set; }
    public float PriceSub { get; set; }
    public string Size { get; set; }
    public int NumberPeople { get; set; }
    public int TotalBasket  { get; set; }
    public string DeliveryTime  { get; set; }
}