using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly GetByIdLanguageBusinessRules _getByIdLanguageBusinessRules;

        public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, GetByIdLanguageBusinessRules getByIdLanguageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _getByIdLanguageBusinessRules = getByIdLanguageBusinessRules;
        }

        public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            var existingLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);
            _getByIdLanguageBusinessRules.ShouldExist(existingLanguage);

            var getByIdLanguageDto = _mapper.Map<GetByIdLanguageDto>(existingLanguage);
            return getByIdLanguageDto;
        }
    }
}
