namespace Chapter11_2_Controllers_K6_BenchmarkDotNet.Controllers;
using Microsoft.AspNetCore.Mvc;

[Route("text-plain")]
[ApiController]
public class TextPlainController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Content("response");
    }
}
