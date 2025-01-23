using CourgeToujoursAPI.API.DTOs.Subscribe;
using CourgeToujoursAPI.BLL.Models.Subscribe;

namespace CourgeToujoursAPI.Mappers.Subscrible;

public static class SubtypeMapper
{
    
    
    public static SubTypeDTO ToDTO(this SubType subType)
    {
        return new SubTypeDTO()
        {
            IdSub = subType.IdSub,
            NameSub = subType.NameSub,
            PriceSub = subType.PriceSub,
            Size = subType.Size,
            NumberPeople = subType.NumberPeople,
            TotalBasket = subType.TotalBasket,
            DeliveryTime = subType.DeliveryTime,
        };
    }


    // TODO faire un to model qi besoin pour changer les info de l'abo
    
    
    
    
    
}