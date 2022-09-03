using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class DeleteLanguageBusinessRules : BaseLanguageBusinessRules
    {
        public DeleteLanguageBusinessRules(ILanguageRepository languageRepository) : base(languageRepository)
        {
        }

        public void ShouldExist(Language? existingLanguage)
        {
            if (existingLanguage == null) throw new BusinessException("Language does not exist.");
        }
    }
}
