using Microsoft.AspNetCore.Mvc;

namespace ReadyMadeATMBackend.Controllers;

[ApiController]
[Route("")]
public class IndexController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Intro()
    {
        return Ok("Frontend aah mudi bro");
    }
}