using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Languages.Rules
{
    public class CreateLanguageBusinessRules : BaseLanguageBusinessRules
    {
        public CreateLanguageBusinessRules(ILanguageRepository languageRepository) : base(languageRepository)
        {
        }

        public async Task LanguageNameCannotBeDuplicated(string name)
        {
            var result = await _languageRepository.GetListAsync(l => l.Name == name);
            if (result?.Items?.Any() == true) throw new BusinessException("Language name already exists.");
        }
    }
}
