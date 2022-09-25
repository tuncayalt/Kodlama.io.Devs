using Application.Features.ApplicationUsers.Commands.DeleteApplicationUser;
using Application.Features.ApplicationUsers.Commands.UpdateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using Application.Features.ApplicationUsers.Queries.GetByIdApplicationUser;
using Application.Features.ApplicationUsers.Queries.GetListApplicationUser;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : BaseController
    {
        public ApplicationUsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationUserCommand updateApplicationUserCommand)
        {
            UpdatedApplicationUserDto result = await _mediator!.Send(updateApplicationUserCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteApplicationUserCommand deleteApplicationUserCommand)
        {
            DeletedApplicationUserDto result = await _mediator!.Send(deleteApplicationUserCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdApplicationUserQuery getByIdApplicationUserQuery)
        {
            GetByIdApplicationUserDto result = await _mediator!.Send(getByIdApplicationUserQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListApplicationUserQuery getListApplicationUserQuery = new() { PageRequest = pageRequest };
            GetListApplicationUsersModel result = await _mediator!.Send(getListApplicationUserQuery);
            return Ok(result);
        }
    }
}
