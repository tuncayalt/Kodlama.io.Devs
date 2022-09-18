using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly GetByIdTechnologyBusinessRules _getByIdTechnologyBusinessRules;

        public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, GetByIdTechnologyBusinessRules getByIdTechnologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _getByIdTechnologyBusinessRules = getByIdTechnologyBusinessRules;
        }

        public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
        {
            var existingTechnology = await _technologyRepository.GetAsync(t => t.Id == request.Id, t => t.Include(a => a.Language));
            _getByIdTechnologyBusinessRules.ShouldExist(existingTechnology);
            _getByIdTechnologyBusinessRules.LanguageShouldExist(existingTechnology.Language);

            var getByIdLanguageDto = _mapper.Map<GetByIdTechnologyDto>(existingTechnology);
            return getByIdLanguageDto;
        }
    }
}
