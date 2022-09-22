using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ApplicationUsers.Rules
{
    public class LoginApplicationUserBusinessRules : BaseApplicationUserBusinessRules
    {
        public void UserShouldExist(ApplicationUser? existingUser)
        {
            if (existingUser == null) throw new BusinessException($"ApplicationUser with this email and password does not exist.");
        }

        public void LoginShouldBeSuccessful(bool loginResult)
        {
            if (loginResult != true) throw new BusinessException($"ApplicationUser with this email and password does not exist.");
        }
    }
}
