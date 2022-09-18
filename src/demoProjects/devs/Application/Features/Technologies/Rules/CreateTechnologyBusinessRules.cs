using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class CreateTechnologyBusinessRules : BaseTechnologyBusinessRules
    {
        public CreateTechnologyBusinessRules(ITechnologyRepository technologyRepository) : base(technologyRepository)
        {
        }

        public async Task TechnologyNameCannotBeDuplicated(string name)
        {
            var result = await _technologyRepository.GetListAsync(l => l.Name == name);
            if (result?.Items?.Any() == true) throw new BusinessException("Technology name already exists.");
        }

        public void LanguageShouldExistInDb(Language? languageInDb)
        {
            if (languageInDb == null) throw new BusinessException("Language does not exist.");
        }
    }
}
