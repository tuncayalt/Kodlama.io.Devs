using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.AuthenticationServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Auth.Commands.LoginCommands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly LoginBusinessRules _loginBusinessRules;

        public LoginCommandHandler(IAuthenticationService authenticationService, IMapper mapper, LoginBusinessRules loginBusinessRules)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _loginBusinessRules = loginBusinessRules;
        }

        public async Task<LoggedInModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
            _loginBusinessRules.UserShouldExist(existingUser);

            var result = new LoggedInModel();
            var loginResult = await _authenticationService.LoginAsync(request, existingUser);
            _loginBusinessRules.LoginShouldBeSuccessful(loginResult);

            result.AccessToken = await _authenticationService.CreateAccessToken(existingUser);
            result.ApplicationUser = _mapper.Map<LoggedInDto>(existingUser);

            return result;
        }
    }
}
