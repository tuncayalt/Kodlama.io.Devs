using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Technologies.Rules
{
    public class DeleteTechnologyBusinessRules : BaseTechnologyBusinessRules
    {
        public DeleteTechnologyBusinessRules(ITechnologyRepository technologyRepository) : base(technologyRepository)
        {
        }

        internal void ShouldExist(Technology? existingTechnology)
        {
            if (existingTechnology == null) throw new BusinessException("Technology does not exist.");
        }
    }
}
