using CourgeToujoursAPI.BLL.Interfaces.Product;
using CourgeToujoursAPI.DTOs.Product;
using CourgeToujoursAPI.Mappers.Product;
using Microsoft.AspNetCore.Mvc;

namespace CourgeToujoursAPI.Controllers.Product;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _ProductService;
    
    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        IEnumerable<ProductDTO> prod;
        try
        {
            prod = _ProductService.GetAllProducts().Select(p => p.ToDTO());
            return Ok(prod);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("id/{id:int}")]
    [ProducesResponseType(200, Type = typeof(ProductDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        try
        {
            ProductDTO? prod = _ProductService.GetById(id)?.ToDTO();
            if (prod != default)
            {
                return Ok(prod);
            }
            
            return NotFound("l'utilsateur n'existe pas");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    
}