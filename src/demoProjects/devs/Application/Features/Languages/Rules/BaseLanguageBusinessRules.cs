using Application.Services.Repositories;

namespace Application.Features.Languages.Rules
{
    public abstract class BaseLanguageBusinessRules
    {
        protected readonly ILanguageRepository _languageRepository;

        public BaseLanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
    }
}