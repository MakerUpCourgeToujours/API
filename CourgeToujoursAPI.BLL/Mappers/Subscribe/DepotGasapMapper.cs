using CourgeToujoursAPI.BLL.Models.Subscribe;
using Entites  = CourgeToujoursAPI.DAL.Entities.Subscribe;

namespace CourgeToujoursAPI.BLL.Mappers.Subscribe;

public static class DepotGasapMapper
{
  public static Entites.DepotGasap toEntity(this DepotGasap depotGasap)
  {
    return new Entites.DepotGasap
    {
      IdGasap = depotGasap.IdGasap,
      Address = depotGasap.Address,
      DeliveryDay = depotGasap.DeliveryDay,
      DepotName = depotGasap.DepotName
    };
  }


  public static DepotGasap toModel(this Entites.DepotGasap entity)
  {
    return new DepotGasap
    {
      IdGasap = entity.IdGasap,
      Address = entity.Address,
      DeliveryDay = entity.DeliveryDay,
      DepotName = entity.DepotName
    };
  }
}