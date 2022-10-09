using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class GetListUserOperationClaimBusinessRules : BaseUserOperationClaimBusinessRules
    {
        public GetListUserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository) : base(userOperationClaimRepository)
        {
        }

        public void UserShouldExist(User? user)
        {
            if (user == null) throw new BusinessException("User does not exist");
        }
    }
}
