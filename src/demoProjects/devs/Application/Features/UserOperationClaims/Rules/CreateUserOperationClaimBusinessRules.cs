using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class CreateUserOperationClaimBusinessRules : BaseUserOperationClaimBusinessRules
    {
        public CreateUserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository) : base(userOperationClaimRepository)
        {
        }

        public void UserShouldExist(User? user)
        {
            if (user == null) throw new BusinessException("User does not exist.");
        }

        public void OperationClaimShouldExist(OperationClaim? operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Operation Claim does not exist.");
        }
    }
}
