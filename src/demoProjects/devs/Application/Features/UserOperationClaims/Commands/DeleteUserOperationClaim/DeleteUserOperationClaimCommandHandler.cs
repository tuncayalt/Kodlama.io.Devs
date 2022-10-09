using Application.Features.ApplicationUsers.Rules;
using Application.Features.Languages.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly DeleteUserOperationClaimBusinessRules _deleteUserOperationClaimBusinessRules;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, DeleteUserOperationClaimBusinessRules deleteUserOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _deleteUserOperationClaimBusinessRules = deleteUserOperationClaimBusinessRules;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id);
            _deleteUserOperationClaimBusinessRules.ShouldExist(userOperationClaim);

            var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim!);
            var deletedUserOperationClaimDto = _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
            return deletedUserOperationClaimDto;
        }
    }
}
