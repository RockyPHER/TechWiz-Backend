using Microsoft.AspNetCore.Mvc;
using TechWiz.Errors;
using TechWiz.Models;
using TechWiz.Services;

namespace TechWiz.Controllers
{
  [Route("technologies")]
  [ApiController]

  public class TechnologyController : ControllerBase
  {

    private readonly ITechnologyService _technologyService;

    public TechnologyController(ITechnologyService technologyService)
    {
        _technologyService = technologyService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTechnology(uint id)
    {   
      var technology = await _technologyService.GetTechnologyByIdAsync(id);
      
      if (technology == null)
        return NotFound(new NotFoundError(nameof(Technology)));
      return Ok(technology);
    }

  }
}