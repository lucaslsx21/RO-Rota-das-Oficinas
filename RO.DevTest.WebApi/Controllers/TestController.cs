using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RO.DevTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protege todos os endpoints desse controller
    public class TestController : ControllerBase
    {
        [HttpGet("protected")]
        public IActionResult GetProtected()
        {
            return Ok(new
            {
                Message = "Você está autenticado!",
                User = User.Identity.Name
            });
        }

        [AllowAnonymous]
        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            return Ok(new
            {
                Message = "Endpoint público, não precisa de autenticação."
            });
        }
    }
}
