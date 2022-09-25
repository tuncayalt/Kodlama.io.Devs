using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.ApplicationUsers.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommandValidator : BaseValidator<DeleteApplicationUserCommand>
    {
        public DeleteApplicationUserCommandValidator()
        {
            RuleFor(l => l.Id).NotNull().GreaterThan(0);
        }
    }
}
