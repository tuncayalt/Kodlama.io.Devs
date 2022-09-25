using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ApplicationUsers.Rules
{
    public class GetByIdApplicationUserBusinessRules : BaseApplicationUserBusinessRules
    {
        public GetByIdApplicationUserBusinessRules(IApplicationUserRepository ApplicationUserRepository) : base(ApplicationUserRepository)
        {
        }

        public void ShouldExist(ApplicationUser? existingApplicationUser)
        {
            if (existingApplicationUser == null) throw new BusinessException("ApplicationUser does not exist.");
        }
    }
}
