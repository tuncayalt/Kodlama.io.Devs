using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
    public class RegisterBusinessRules : BaseAuthBusinessRules
    {
        internal void UserShouldNotExist(ApplicationUser? existingUser)
        {
            if (existingUser != null) throw new BusinessException($"ApplicationUser with email {existingUser.User.Email} already exists.");
        }
    }
}
