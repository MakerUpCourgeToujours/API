using System.ComponentModel.DataAnnotations;
using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DTOs.Login;
using CourgeToujoursAPI.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CourgeToujoursAPI.Controllers.Login;


[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    //------------------------------------------------------------
    
    
    //CREATE USER B2C//
    [HttpPost("B2CUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateB2CUser([FromBody] UserB2CDTO user)
    {
        try
        {
            UserB2CDTO newUser = _userService.CreateUserB2C(user.toModel()).toDTO();
            return Ok(newUser);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError);
        }
    }
    
}