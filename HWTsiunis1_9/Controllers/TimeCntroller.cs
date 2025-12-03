using Microsoft.AspNetCore.Mvc;

namespace HwVar_1And9.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TimeController : ControllerBase
{

    [HttpGet]
    public ActionResult<DateTime> Get()
    {
        return Ok(DateTime.UtcNow);
    }
}