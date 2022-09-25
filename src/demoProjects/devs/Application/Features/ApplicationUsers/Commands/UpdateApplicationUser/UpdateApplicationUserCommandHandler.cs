using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, UpdatedApplicationUserDto>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly UpdateApplicationUserBusinessRules _updateApplicationUserBusinessRules;

        public UpdateApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, UpdateApplicationUserBusinessRules updateApplicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _updateApplicationUserBusinessRules = updateApplicationUserBusinessRules;
        }

        public async Task<UpdatedApplicationUserDto> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var existingApplicationUser = await _applicationUserRepository.GetAsync(l => l.Id == request.Id);

            _updateApplicationUserBusinessRules.ShouldExist(existingApplicationUser);
            await _updateApplicationUserBusinessRules.ApplicationUserCannotBeDuplicated(request.Id, request.UserId);

            _mapper.Map(request, existingApplicationUser);
            var updatedApplicationUser = await _applicationUserRepository.UpdateAsync(existingApplicationUser!);
            var updatedApplicationUserDto = _mapper.Map<UpdatedApplicationUserDto>(updatedApplicationUser);
            return updatedApplicationUserDto;
        }
    }
}
