using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Auth.Commands.LoginCommands
{
    public class LoginCommandValidator : BaseValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
}
