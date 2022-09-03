using Application.Features.Languages.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListLanguagesModel>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetListLanguagesModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            var languages = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            var getListLanguageModel = _mapper.Map<GetListLanguagesModel>(languages);
            return getListLanguageModel;
        }
    }
}
