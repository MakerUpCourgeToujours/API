using CourgeToujoursAPI.API.DTOs.Subscribe;
using CourgeToujoursAPI.BLL.Interfaces.Subscribe;
using CourgeToujoursAPI.DAL.Entities.Subscribe;
using CourgeToujoursAPI.Mappers.Subscrible;
using Microsoft.AspNetCore.Mvc;

namespace CourgeToujoursAPI.Controllers.Subscrible;

[Route("api/[controller]")]
[ApiController]
public class SubTypeController : ControllerBase
{
    private readonly ISubTypeService _subTypeService;

    public SubTypeController(ISubTypeService subTypeService)
    {
        _subTypeService = subTypeService;
    }

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
    
    
}