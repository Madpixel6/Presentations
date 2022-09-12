using Microsoft.AspNetCore.Mvc;

namespace MemLeakEvents.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaksController : ControllerBase
{
    private readonly ILogger<LeaksController> _logger;

    public LeaksController(ILogger<LeaksController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<> Get()
    {
    }
}