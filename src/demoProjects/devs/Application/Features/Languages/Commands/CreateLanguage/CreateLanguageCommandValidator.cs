using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(CreateLanguageCommand), $"{nameof(CreateLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
