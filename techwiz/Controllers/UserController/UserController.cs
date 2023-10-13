using Microsoft.AspNetCore.Mvc;
using TechWiz.Errors;
using TechWiz.Models;
using TechWiz.Services;

namespace TechWiz.Controllers
{
  [Route("[controller]s")]
  [ApiController]

  public class UserController : ControllerBase
  {

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {   
      if (!uint.TryParse(id, out uint userId) || userId <= 0)
        return BadRequest(new InvalidFieldError("Id"));

      var user = await _userService.GetUserByIdAsync(userId);
      
      if (user == null)
        return NotFound(new NotFoundError(nameof(User)));
      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserModel body)
    {   
      if (body == null)
        return BadRequest();

      var user = await _userService.CreateUserAsync(body);        
      
      if (string.IsNullOrWhiteSpace(body.Name) || string.IsNullOrWhiteSpace(body.Email))
        return BadRequest(new BadRequestBodyError());
      return Created(nameof(CreateUser), user);

    }

  }
}