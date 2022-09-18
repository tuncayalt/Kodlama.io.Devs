using Core.Application.Validation;
using FluentValidation;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQueryValidator : BaseValidator<GetByIdTechnologyQuery>
    {
        public GetByIdTechnologyQueryValidator()
        {
            RuleFor(t => t.Id).NotNull().GreaterThan(0);
        }
    }
}
