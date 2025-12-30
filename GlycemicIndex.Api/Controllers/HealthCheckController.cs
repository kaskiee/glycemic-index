using Microsoft.AspNetCore.Mvc;

namespace GlycemicIndex.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
    }
}

