using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Features.Auth.Rules;
using Application.Services.AuthenticationServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Auth.Commands.RegisterCommands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly RegisterBusinessRules _registerBusinessRules;

        public RegisterCommandHandler(IAuthenticationService authenticationService, IMapper mapper, RegisterBusinessRules registerBusinessRules)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _registerBusinessRules = registerBusinessRules;
        }

        public async Task<RegisteredModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
            _registerBusinessRules.UserShouldNotExist(existingUser);

            var result = new RegisteredModel();
            var createdApplicationUser = await _authenticationService.RegisterAsync(request);
            result.ApplicationUser = _mapper.Map<RegisteredDto>(createdApplicationUser);
            result.AccessToken = await _authenticationService.CreateAccessToken(createdApplicationUser);
            result.RefreshToken = await _authenticationService.CreateRefreshToken(createdApplicationUser.User, request.IpAddress);

            await _authenticationService.AddRefreshToken(result.RefreshToken);

            return result;
        }
    }
}
