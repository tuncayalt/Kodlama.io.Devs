using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryValidator : BaseValidator<GetListLanguageQuery>
    {
        public GetListLanguageQueryValidator()
        {
            RuleFor(l => l.PageRequest).NotNull();
        }
    }
}
