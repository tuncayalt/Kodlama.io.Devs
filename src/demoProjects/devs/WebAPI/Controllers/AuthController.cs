using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Commands.LoginCommands;
using Application.Features.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Security.Entities;
using Application.Features.Auth.Dtos;
using AutoMapper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerCommand = _mapper.Map<RegisterCommand>(registerDto);
            registerCommand.IpAddress = GetIpAddress();

            RegisteredModel result = await _mediator!.Send(registerCommand);

            SetRefreshTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            LoggedInModel result = await _mediator!.Send(loginCommand);
            return Ok(result);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(1),
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
