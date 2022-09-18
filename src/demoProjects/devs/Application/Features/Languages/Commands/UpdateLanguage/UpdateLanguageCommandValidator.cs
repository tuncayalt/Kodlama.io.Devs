using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : BaseValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotNull()
                .GreaterThan(0);

            RuleFor(u => u.Name).NotEmpty().MaximumLength(64);
        }
    }
}
