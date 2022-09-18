using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : BaseValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(l => l.Id).NotEmpty().GreaterThan(0);
            RuleFor(l => l.Name).NotEmpty().MaximumLength(64);
            RuleFor(l => l.LanguageId).NotEmpty().GreaterThan(0);
        }
    }
}
