using FluentValidation;
using FluentValidation.Results;

namespace Core.Application.Validation
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(T), $"{nameof(T)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
