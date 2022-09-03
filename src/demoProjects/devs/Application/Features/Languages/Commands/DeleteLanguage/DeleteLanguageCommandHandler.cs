using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly DeleteLanguageBusinessRules _deleteLanguageBusinessRules;

        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, DeleteLanguageBusinessRules deleteLanguageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _deleteLanguageBusinessRules = deleteLanguageBusinessRules;
        }

        public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var existingLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);

            _deleteLanguageBusinessRules.ShouldExist(existingLanguage);

            var deletedLanguage = await _languageRepository.DeleteAsync(existingLanguage!);
            var deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);
            return deletedLanguageDto;
        }
    }
}
