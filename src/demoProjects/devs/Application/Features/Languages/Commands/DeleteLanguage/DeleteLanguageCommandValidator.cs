using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotNull()
                .GreaterThan(0);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(DeleteLanguageCommand), $"{nameof(DeleteLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
