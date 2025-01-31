using System.ComponentModel.DataAnnotations;
using CourgeToujoursAPI.BLL.Interfaces.login;
using CourgeToujoursAPI.BLL.Models.login;
using CourgeToujoursAPI.DTOs.Login;
using CourgeToujoursAPI.Mappers.login;
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
    
    //CREATE USER B2B//
    [HttpPost("B2BUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateB2BUser([FromBody] UserB2BDTO user)
    {
        try
        {
            UserB2BDTO newUser = _userService.CreateUserB2B(user.ToModel()).ToDto();
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


    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public IActionResult Login([FromBody] LoginUserDTO user)
    {
        try
        {
            string token = _userService.Login(user.ToModelsLogin());

            return Ok(new
            {
                token,
                email = user.Email
            });
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return NotFound("Les credentials de l'utilisateur·ice sont incorrect");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    
    
    
    
}