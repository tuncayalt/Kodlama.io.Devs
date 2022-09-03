using FluentValidation;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryValidator : AbstractValidator<GetListLanguageQuery>
    {
        public GetListLanguageQueryValidator()
        {
            RuleFor(l => l.PageRequest).NotNull();
        }
    }
}
