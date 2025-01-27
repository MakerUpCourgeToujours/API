

using CourgeToujoursAPI.BLL.Models.Subscribe;

namespace CourgeToujoursAPI.BLL.Interfaces.Subscribe;

public interface IDepotGasapService
{
    public IEnumerable<DepotGasap> GetAll();
}