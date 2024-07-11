using Microsoft.AspNetCore.Mvc;
using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Controllers;

[ApiController]
[Route("")]
public class IndexController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Intro()
    {
        return Ok(new User { Id = 1, Name = "Alice", AtmNumber = "1234567890", Pin = 1234, Balance = 1000 });
    }
}