using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Commands.LoginCommands;
using Application.Features.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisteredModel result = await _mediator!.Send(registerCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            LoggedInModel result = await _mediator!.Send(loginCommand);
            return Ok(result);
        }
    }
}
