using FluentValidation;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQueryValidator : AbstractValidator<GetListUserOperationClaimQuery>
    {
        public GetListUserOperationClaimQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
