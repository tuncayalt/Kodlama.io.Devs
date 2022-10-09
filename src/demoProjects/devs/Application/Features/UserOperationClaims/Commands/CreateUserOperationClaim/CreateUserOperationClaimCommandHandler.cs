using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly CreateUserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(
            IUserOperationClaimRepository userOperationClaimRepository,
            IUserRepository userRepository,
            IOperationClaimRepository operationClaimRepository,
            IMapper mapper,
            CreateUserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.UserId);
            _userOperationClaimBusinessRules.UserShouldExist(user);

            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.OperationClaimId);
            _userOperationClaimBusinessRules.OperationClaimShouldExist(operationClaim);

            var mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            var createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
            var createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationClaimDto;
        }
    }
}
