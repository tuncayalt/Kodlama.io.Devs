using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandValidator : BaseValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
