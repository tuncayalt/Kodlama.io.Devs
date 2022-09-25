using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ApplicationUsers.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, DeletedApplicationUserDto>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        private readonly DeleteApplicationUserBusinessRules _deleteApplicationUserBusinessRules;

        public DeleteApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, DeleteApplicationUserBusinessRules deleteApplicationUserBusinessRules)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
            _deleteApplicationUserBusinessRules = deleteApplicationUserBusinessRules;
        }

        public async Task<DeletedApplicationUserDto> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var existingApplicationUser = await _applicationUserRepository.GetAsync(l => l.Id == request.Id);

            _deleteApplicationUserBusinessRules.ShouldExist(existingApplicationUser);

            var deletedApplicationUser = await _applicationUserRepository.DeleteAsync(existingApplicationUser!);
            var deletedApplicationUserDto = _mapper.Map<DeletedApplicationUserDto>(deletedApplicationUser);
            return deletedApplicationUserDto;
        }
    }
}
