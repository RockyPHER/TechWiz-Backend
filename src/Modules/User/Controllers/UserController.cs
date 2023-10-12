using Microsoft.AspNetCore.Mvc;
using TechWiz.Models;
using TechWiz.Services;

namespace TechWiz.Controllers
{
  [Route("users")]
  [ApiController]

  public class UserController : ControllerBase
  {

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // [HttpGet]
    // public ActionResult<List<User>> GetUsers()
    // {
    //     return Ok(userList);
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(uint id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserModel body)
    {
        var user = await _userService.CreateUserAsync(body);        
        return Created(nameof(CreateUser), user);

    }

  }
}