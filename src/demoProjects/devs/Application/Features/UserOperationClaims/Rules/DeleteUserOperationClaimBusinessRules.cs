using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class DeleteUserOperationClaimBusinessRules : BaseUserOperationClaimBusinessRules
    {
        public DeleteUserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository) : base(userOperationClaimRepository)
        {
        }

        public void ShouldExist(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("User Operation Claim does not exist.");
        }
    }
}
