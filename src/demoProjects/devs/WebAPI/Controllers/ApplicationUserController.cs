using Application.Features.ApplicationUsers.Commands.CreateApplicationUser;
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

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateApplicationUserCommand createApplicationUserCommand)
        {
            CreatedApplicationUserModel result = await _mediator!.Send(createApplicationUserCommand);
            return Created("", result);
        }
    }
}
