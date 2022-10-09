using Application.Services.Repositories;

namespace Application.Features.UserOperationClaims.Rules
{
    public class BaseUserOperationClaimBusinessRules
    {
        protected readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public BaseUserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }
    }
}