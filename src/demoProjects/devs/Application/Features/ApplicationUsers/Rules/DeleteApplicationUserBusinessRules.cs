using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ApplicationUsers.Rules
{
    public class DeleteApplicationUserBusinessRules : BaseApplicationUserBusinessRules
    {
        public DeleteApplicationUserBusinessRules(IApplicationUserRepository applicationUserRepository) : base(applicationUserRepository)
        {
        }

        public void ShouldExist(ApplicationUser? existingApplicationUser)
        {
            if (existingApplicationUser == null) throw new BusinessException("ApplicationUser does not exist.");
        }
    }
}
