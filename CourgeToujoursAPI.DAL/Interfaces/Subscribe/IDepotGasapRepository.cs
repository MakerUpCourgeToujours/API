using CourgeToujoursAPI.DAL.Entities.Subscribe;

namespace CourgeToujoursAPI.DAL.Interfaces.Subscribe;

public interface IDepotGasapRepository
{
    public IEnumerable<DepotGasap> GetAll();
    
    
    
}