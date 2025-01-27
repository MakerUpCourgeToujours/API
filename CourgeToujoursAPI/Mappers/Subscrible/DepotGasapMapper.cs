using CourgeToujoursAPI.API.DTOs.Subscribe;
using CourgeToujoursAPI.BLL.Models.Subscribe;

namespace CourgeToujoursAPI.Mappers.Subscrible;

public static class DepotGasapMapper
{
   public static DepotGasapDTO toDTO(this DepotGasap depotGasap)
   {
      return new DepotGasapDTO()
      {
         IdGasap = depotGasap.IdGasap,
         Address = depotGasap.Address,
         DepotName = depotGasap.DepotName,
         DeliveryDay = depotGasap.DeliveryDay
      };
   }
}

// TODO faire un to model si besoin pour faire un post 