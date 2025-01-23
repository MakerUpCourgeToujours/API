using CourgeToujoursAPI.BLL.Models.Subscribe;
using Entities = CourgeToujoursAPI.DAL.Entities.Subscribe;


namespace CourgeToujoursAPI.BLL.Mappers.Subscribe;



public static class SubTypeMapper
{

    public static Entities.SubType toEntity (this SubType subType)
    {
        return new Entities.SubType
        {
            IdSub = subType.IdSub,
            NameSub = subType.NameSub,
            PriceSub = subType.PriceSub,
            Size = subType.Size,
            NumberPeople = subType.NumberPeople,
            TotalBasket = subType.TotalBasket,
            DeliveryTime = subType.DeliveryTime
        };
    }
    
    public static SubType toModel(this Entities.SubType subType)
    {
        return new SubType
        {

            IdSub = subType.IdSub,
            NameSub = subType.NameSub,
            PriceSub = subType.PriceSub,
            Size = subType.Size,
            NumberPeople = subType.NumberPeople,
            TotalBasket = subType.TotalBasket,
            DeliveryTime = subType.DeliveryTime

        };

    }
    
    
}