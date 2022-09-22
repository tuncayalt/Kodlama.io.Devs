using FluentValidation;

namespace Application.Features.ApplicationUsers.Commands.LoginApplicationUser
{
    public class LoginApplicationUserCommandValidator : AbstractValidator<LoginApplicationUserCommand>
    {
        public LoginApplicationUserCommandValidator()
        {
            RuleFor(l => l.Email).NotEmpty().EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
}
