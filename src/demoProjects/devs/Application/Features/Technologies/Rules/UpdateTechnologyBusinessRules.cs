using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class UpdateTechnologyBusinessRules : BaseTechnologyBusinessRules
    {
        public UpdateTechnologyBusinessRules(ITechnologyRepository technologyRepository) : base(technologyRepository)
        {
        }

        public void LanguageShouldExistInDb(Language? languageInDb)
        {
            if (languageInDb == null) throw new BusinessException("Language does not exist.");
        }

        public void TechnologyShouldExistInDb(Technology? technologyInDb)
        {
            if (technologyInDb == null) throw new BusinessException("Technology does not exist.");
        }

        public async Task TechnologyNameCannotBeDuplicated(int id, string name)
        {
            var result = await _technologyRepository.GetListAsync(l => l.Name == name && l.Id != id);
            if (result?.Items?.Any() == true) throw new BusinessException("Technology name already exists.");
        }
    }
}
