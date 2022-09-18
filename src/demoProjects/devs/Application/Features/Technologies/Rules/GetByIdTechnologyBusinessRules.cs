using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class GetByIdTechnologyBusinessRules : BaseTechnologyBusinessRules
    {
        public GetByIdTechnologyBusinessRules(ITechnologyRepository technologyRepository) : base(technologyRepository)
        {
        }

        internal void LanguageShouldExist(Language? language)
        {
            if (language == null) throw new BusinessException("Language does not exist.");
        }

        internal void ShouldExist(Technology? existingTechnology)
        {
            if (existingTechnology == null) throw new BusinessException("Technology does not exist.");
        }
    }
}
