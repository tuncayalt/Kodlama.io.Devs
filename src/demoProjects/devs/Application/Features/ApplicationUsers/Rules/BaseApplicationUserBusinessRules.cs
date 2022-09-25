using Application.Services.Repositories;

namespace Application.Features.ApplicationUsers.Rules
{
    public abstract class BaseApplicationUserBusinessRules
    {
        protected readonly IApplicationUserRepository _applicationUserRepository;

        public BaseApplicationUserBusinessRules(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
    }
}