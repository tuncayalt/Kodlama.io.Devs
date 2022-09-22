using Application.Features.ApplicationUsers.Commands.CreateApplicationUser;
using Application.Features.ApplicationUsers.Commands.LoginApplicationUser;
using Application.Features.ApplicationUsers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        public ApplicationUserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateApplicationUserCommand createApplicationUserCommand)
        {
            CreatedApplicationUserModel result = await _mediator!.Send(createApplicationUserCommand);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginApplicationUserCommand loginApplicationUserCommand)
        {
            LoggedInApplicationUserModel result = await _mediator!.Send(loginApplicationUserCommand);
            return Ok(result);
        }
    }
}
