using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.ApplicationUsers.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommandValidator : BaseValidator<UpdateApplicationUserCommand>
    {
        public UpdateApplicationUserCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().GreaterThan(0);

            RuleFor(u => u.UserId).NotNull().GreaterThan(0);
        }
    }
}
