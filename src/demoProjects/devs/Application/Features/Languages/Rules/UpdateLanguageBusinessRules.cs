using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class UpdateLanguageBusinessRules : BaseLanguageBusinessRules
    {
        public UpdateLanguageBusinessRules(ILanguageRepository languageRepository) : base(languageRepository)
        {
        }

        public void ShouldExist(Language? existingLanguage)
        {
            if (existingLanguage == null) throw new BusinessException("Language does not exist.");
        }

        public async Task LanguageNameCannotBeDuplicated(int id, string name)
        {
            var result = await _languageRepository.GetListAsync(l => l.Name == name && l.Id != id);
            if (result?.Items?.Any() == true) throw new BusinessException("Language name already exists.");
        }
    }
}
