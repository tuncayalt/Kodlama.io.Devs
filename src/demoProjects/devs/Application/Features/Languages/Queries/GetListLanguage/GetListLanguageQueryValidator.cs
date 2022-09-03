using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryValidator : AbstractValidator<GetListLanguageQuery>
    {
        public GetListLanguageQueryValidator()
        {
            RuleFor(l => l.PageRequest).NotNull();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetListLanguageQuery> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(GetListLanguageQuery), $"{nameof(GetListLanguageQuery)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
