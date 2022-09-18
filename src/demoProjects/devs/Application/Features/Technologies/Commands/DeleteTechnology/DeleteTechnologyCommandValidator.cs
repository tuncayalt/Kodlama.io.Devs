using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator : BaseValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
