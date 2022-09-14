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

    [HttpGet("Xml")]
    public IActionResult GetXmlLeakSummary()
    {
        MemLeaks.RunXmlMemoryLeak();
        
        return Ok();
    }
    
    [HttpGet("XmlCache")]
    public IActionResult GetXmlCachedSummary()
    {
        MemLeaks.RunXmlCached();
        return Ok();
    }
    
    [HttpGet("StaticRef")]
    public IActionResult GetSomeBigString()
    {
        var result = MemLeaks.RunStringAllocation();

        return Ok(result);
    }

    [HttpGet("Thread")]
    public IActionResult GetNeverTerminatingThread()
    {
        MemLeaks.RunNeverTerminatingThread();
        return Ok();
    }
    [HttpGet("Events")]
    public IActionResult GetEventsMemoryLeak()
    {
        MemLeaks.RunEventsMemoryLeak();
        return Ok();
    }
}