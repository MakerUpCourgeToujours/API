using CourgeToujoursAPI.BLL.Interfaces.Product;
using CourgeToujoursAPI.DTOs.Product;
using CourgeToujoursAPI.Mappers.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if (prod != null)
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

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] ProductCreateDTO product)
    {
        int resultId = _ProductService.create(product.toModel());

        if (resultId > 0)
        {
            ProductDTO p = _ProductService.GetById(resultId)!.ToDTO();
            return CreatedAtAction(nameof(GetById), new { id = resultId }, p);
        }
        
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateProduct([FromBody] ProductCreateDTO productupdate)
    {
        try
        {
            var product = _ProductService.GetById(productupdate.id_product);
            if (product.id_product == null)
            {
                return NotFound(new { success = false, message = $"Produit avec l'ID {productupdate.id_product} non trouvé" });
                
            }

            bool updateSuccess = _ProductService.update(productupdate.toModel());

            
            return Ok(new { success = updateSuccess });
            



        }
        catch (Exception e)
        {
            return StatusCode(500, new { success = false, message = "Une erreur est survenue lors de la mise à jour du produit" });
        }
    }
    
}