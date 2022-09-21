using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.AuthenticationServices;
using AutoMapper;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.CreateApplicationUser
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, CreatedApplicationUserModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly CreateApplicationUserBusinessRules _createApplicationUserBusinessRules;

        public CreateApplicationUserCommandHandler(IAuthenticationService authenticationService, IMapper mapper, CreateApplicationUserBusinessRules createApplicationUserBusinessRules)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _createApplicationUserBusinessRules = createApplicationUserBusinessRules;
        }

        public async Task<CreatedApplicationUserModel> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _authenticationService.GetUserByEmailAsync(request.Email);
            _createApplicationUserBusinessRules.UserShouldNotExist(existingUser);

            var result = new CreatedApplicationUserModel();
            var createdApplicationUser = await _authenticationService.RegisterAsync(request);
            result.ApplicationUser = _mapper.Map<CreatedApplicationUserDto>(createdApplicationUser);
            result.AccessToken = await _authenticationService.CreateAccessToken(createdApplicationUser);

            return result;
        }
    }
}
