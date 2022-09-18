using Application.Services.Repositories;

namespace Application.Features.Technologies.Rules
{
    public abstract class BaseTechnologyBusinessRules
    {
        protected readonly ITechnologyRepository _technologyRepository;

        public BaseTechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
    }
}
