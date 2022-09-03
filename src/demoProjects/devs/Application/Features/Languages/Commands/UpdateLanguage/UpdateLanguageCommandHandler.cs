using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly UpdateLanguageBusinessRules _updateLanguageBusinessRules;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, UpdateLanguageBusinessRules updateLanguageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _updateLanguageBusinessRules = updateLanguageBusinessRules;
        }

        public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var existingLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);

            _updateLanguageBusinessRules.ShouldExist(existingLanguage);
            await _updateLanguageBusinessRules.LanguageNameCannotBeDuplicated(request.Id, request.Name);

            _mapper.Map(request, existingLanguage);
            var updatedLanguage = await _languageRepository.UpdateAsync(existingLanguage);
            var updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);
            return updatedLanguageDto;
        }
    }
}
