using GlycemicIndex.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GlycemicIndex.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping(DbContextGI dbcontext)
    {
        var result = dbcontext.Database.CanConnect();
        return Ok(new { status = "healthy", timestamp = DateTime.UtcNow, db = result });
    }
}