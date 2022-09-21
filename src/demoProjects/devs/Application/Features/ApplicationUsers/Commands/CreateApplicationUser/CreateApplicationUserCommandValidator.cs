using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.ApplicationUsers.Commands.CreateApplicationUser
{
    public class CreateApplicationUserCommandValidator : BaseValidator<CreateApplicationUserCommand>
    {
        public CreateApplicationUserCommandValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
            RuleFor(a => a.Email).NotEmpty().EmailAddress();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.ConfirmPassword).NotEmpty().Equal(a => a.Password).WithMessage("'Confirm Password' must be equal to 'Password'");
            RuleFor(a => a.GitHubAddress).NotEmpty();
        }
    }
}
