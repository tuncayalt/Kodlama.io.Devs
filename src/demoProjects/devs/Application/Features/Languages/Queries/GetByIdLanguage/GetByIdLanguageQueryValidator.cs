using FluentValidation;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQueryValidator : AbstractValidator<GetByIdLanguageQuery>
    {
        public GetByIdLanguageQueryValidator()
        {
            RuleFor(l => l.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
