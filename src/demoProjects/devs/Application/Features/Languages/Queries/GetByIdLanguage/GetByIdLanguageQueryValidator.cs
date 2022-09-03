using FluentValidation;
using FluentValidation.Results;

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

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetByIdLanguageQuery> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(GetByIdLanguageQuery), $"{nameof(GetByIdLanguageQuery)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
