using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly UpdateTechnologyBusinessRules _updateTechnologyBusinessRules;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, ILanguageRepository languageRepository, IMapper mapper, UpdateTechnologyBusinessRules updateTechnologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _languageRepository = languageRepository;
            _mapper = mapper;
            _updateTechnologyBusinessRules = updateTechnologyBusinessRules;
        }

        public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            var existingTechnology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

            _updateTechnologyBusinessRules.TechnologyShouldExistInDb(existingTechnology);
            await _updateTechnologyBusinessRules.TechnologyNameCannotBeDuplicated(request.Id, request.Name);

            var languageInDb = await _languageRepository.GetAsync(t => t.Id == request.LanguageId);
            _updateTechnologyBusinessRules.LanguageShouldExistInDb(languageInDb);

            _mapper.Map(request, existingTechnology);
            var updatedTechnology = await _technologyRepository.UpdateAsync(existingTechnology);
            var updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
            return updatedTechnologyDto;
        }
    }
}
