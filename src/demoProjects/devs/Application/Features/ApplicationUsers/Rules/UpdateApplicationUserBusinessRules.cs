using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.Features.ApplicationUsers.Rules
{
    public class UpdateApplicationUserBusinessRules : BaseApplicationUserBusinessRules
    {
        public UpdateApplicationUserBusinessRules(IApplicationUserRepository applicationUserRepository) : base(applicationUserRepository)
        {
        }

        public void ShouldExist(ApplicationUser? existingApplicationUser)
        {
            if (existingApplicationUser == null) throw new BusinessException("ApplicationUser does not exist.");
        }

        public async Task ApplicationUserCannotBeDuplicated(int id, int userId)
        {
            var result = await _applicationUserRepository.GetListAsync(l => l.UserId == userId && l.Id != id);
            if (result?.Items?.Any() == true) throw new BusinessException("ApplicationUser already exists.");
        }
    }
}
