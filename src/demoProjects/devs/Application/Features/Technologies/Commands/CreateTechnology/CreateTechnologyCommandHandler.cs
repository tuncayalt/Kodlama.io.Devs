using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly CreateTechnologyBusinessRules _technologyBusinessRules;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, ILanguageRepository languageRepository, IMapper mapper, CreateTechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.TechnologyNameCannotBeDuplicated(request.Name);

            var languageInDb = await _languageRepository.GetAsync(l => l.Id == request.LanguageId);

            _technologyBusinessRules.LanguageShouldExistInDb(languageInDb);

            var mappedTechnology = _mapper.Map<Technology>(request);
            var createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
            var createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createdTechnology);
            return createdTechnologyDto;
        }
    }
}
