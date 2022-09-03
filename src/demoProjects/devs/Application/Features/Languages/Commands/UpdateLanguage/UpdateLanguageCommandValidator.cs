using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotNull()
                .GreaterThan(0);

            RuleFor(u => u.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(UpdateLanguageCommand), $"{nameof(UpdateLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
