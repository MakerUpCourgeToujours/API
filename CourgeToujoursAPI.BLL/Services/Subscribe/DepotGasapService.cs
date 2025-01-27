using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.BLL.Mappers.Subscribe;
using CourgeToujoursAPI.BLL.Models.Subscribe;
using CourgeToujoursAPI.DAL.Interfaces.Subscribe;

namespace CourgeToujoursAPI.BLL.Services.Subscribe;

public class DepotGasapService :IDepotGasapService
{
    private readonly IDepotGasapRepository _depotGasapRepository;

    public DepotGasapService(IDepotGasapRepository depotGasapRepository)
    {
        _depotGasapRepository = depotGasapRepository;
    }
    
    
    public IEnumerable<DepotGasap> GetAll()
    {
        return _depotGasapRepository.GetAll().Select(depot => depot.toModel());
    }
}