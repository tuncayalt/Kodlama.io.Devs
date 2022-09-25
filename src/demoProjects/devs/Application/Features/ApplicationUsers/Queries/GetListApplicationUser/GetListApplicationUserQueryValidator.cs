using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.ApplicationUsers.Queries.GetListApplicationUser
{
    public class GetListApplicationUserQueryValidator : BaseValidator<GetListApplicationUserQuery>
    {
        public GetListApplicationUserQueryValidator()
        {
            RuleFor(l => l.PageRequest).NotNull();
        }
    }
}
