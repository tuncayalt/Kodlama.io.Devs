using Application.Features.Languages.Dtos;
using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
    {
        public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository)
        {

        }

        public Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
