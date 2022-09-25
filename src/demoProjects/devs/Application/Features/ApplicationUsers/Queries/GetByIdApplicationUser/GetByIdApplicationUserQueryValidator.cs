using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.ApplicationUsers.Queries.GetByIdApplicationUser
{
    public class GetByIdApplicationUserQueryValidator : BaseValidator<GetByIdApplicationUserQuery>
    {
        public GetByIdApplicationUserQueryValidator()
        {
            RuleFor(l => l.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
