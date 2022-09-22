using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.AuthenticationServices;
using AutoMapper;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.LoginApplicationUser
{
    public class LoginApplicationUserCommandHandler : IRequestHandler<LoginApplicationUserCommand, LoggedInApplicationUserModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly LoginApplicationUserBusinessRules _loginApplicationUserBusinessRules;

        public LoginApplicationUserCommandHandler(IAuthenticationService authenticationService, IMapper mapper, LoginApplicationUserBusinessRules loginApplicationUserBusinessRules)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _loginApplicationUserBusinessRules = loginApplicationUserBusinessRules;
        }

        public async Task<LoggedInApplicationUserModel> Handle(LoginApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
            _loginApplicationUserBusinessRules.UserShouldExist(existingUser);

            var result = new LoggedInApplicationUserModel();
            var loginResult = await _authenticationService.LoginAsync(request, existingUser);
            _loginApplicationUserBusinessRules.LoginShouldBeSuccessful(loginResult);

            result.AccessToken = await _authenticationService.CreateAccessToken(existingUser);
            result.ApplicationUser = _mapper.Map<LoggedInApplicationUserDto>(existingUser);

            return result;
        }
    }
}
