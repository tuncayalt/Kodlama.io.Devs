using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQueryValidator : BaseValidator<GetByIdLanguageQuery>
    {
        public GetByIdLanguageQueryValidator()
        {
            RuleFor(l => l.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
