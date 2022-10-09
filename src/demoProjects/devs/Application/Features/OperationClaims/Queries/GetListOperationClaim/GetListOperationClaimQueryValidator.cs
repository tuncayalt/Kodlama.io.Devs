using FluentValidation;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQueryValidator : AbstractValidator<GetListOperationClaimQuery>
    {
        public GetListOperationClaimQueryValidator()
        {
            RuleFor(x => x.PageRequest).NotEmpty();
        }
    }
}
