using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandValidator : BaseValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty().MaximumLength(64);
        }
    }
}
