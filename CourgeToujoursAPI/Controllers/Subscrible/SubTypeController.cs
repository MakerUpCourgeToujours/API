using CourgeToujoursAPI.API.DTOs.Subscribe;
using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.DAL.Entities.Subscribe;
using CourgeToujoursAPI.Mappers.Subscrible;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//[Authorize(Roles = "Admin")]// pour les role dans api //
namespace CourgeToujoursAPI.Controllers.Subscrible;

[Route("api/[controller]")]
[ApiController]
public class SubTypeController : ControllerBase
{
    private readonly ISubTypeService _subTypeService;
    private readonly IDepotGasapService _depotGasapService;
    
    public SubTypeController(ISubTypeService subTypeService,IDepotGasapService depotGasapService)
    {
        _subTypeService = subTypeService;
        _depotGasapService = depotGasapService;
    }
    
    //----------------------------------------------------------------------------------------------------//
    
    // sub //
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<SubType>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        IEnumerable<SubTypeDTO> subs;
        try
        {
            subs = _subTypeService.GetAll().Select(sub => sub.ToDTO());
            return Ok(subs);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    // Depot // 

    [HttpGet("depotGasap")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<DepotGasapDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllDepotGasap()
    {
        IEnumerable<DepotGasapDTO> depotGasap;
        try
        {
            depotGasap = _depotGasapService.GetAll().Select(depot => depot.toDTO());
            return Ok(depotGasap);

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    
}