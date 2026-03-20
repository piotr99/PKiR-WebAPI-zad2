using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScriptController : Controller
    {
        [HttpPost("weatherPresenterScript")]
        public async Task<IActionResult> PostScript(string script, [FromServices] IScriptService scriptService)
        {
            var isSuccess = await scriptService.PostScript(script);
            return isSuccess ? Ok("działa") : BadRequest("bład czegos");
        }
    }
}
