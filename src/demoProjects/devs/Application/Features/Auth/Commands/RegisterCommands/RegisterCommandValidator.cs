using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Auth.Commands.RegisterCommands
{
    public class RegisterCommandValidator : BaseValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
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
