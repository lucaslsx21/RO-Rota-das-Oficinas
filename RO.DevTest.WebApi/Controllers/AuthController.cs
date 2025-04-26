using MediatR;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

namespace RO.DevTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            // Envia o comando de login para o Mediator e obtém a resposta
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
