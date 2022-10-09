using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandValidator : BaseValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimCommandValidator()
        {
            RuleFor(u => u.UserId).NotEmpty().GreaterThan(0);
            RuleFor(u => u.OperationClaimId).NotEmpty().GreaterThan(0);
        }
    }
}
