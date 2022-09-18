using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator : BaseValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty().MaximumLength(64);
            RuleFor(l => l.LanguageId).NotEmpty().GreaterThan(0);
        }
    }
}
