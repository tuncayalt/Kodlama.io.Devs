using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly CreateLanguageBusinessRules _languageBusinessRules;

        public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, CreateLanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _languageBusinessRules.LanguageNameCannotBeDuplicated(request.Name);

            var mappedLanguage = _mapper.Map<Language>(request);
            var createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
            var createdLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);
            return createdLanguageDto;
        }
    }
}
