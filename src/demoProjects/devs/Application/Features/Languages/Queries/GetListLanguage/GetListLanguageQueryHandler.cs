using Application.Features.Languages.Models;
using MediatR;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListLanguagesModel>
    {
        public Task<GetListLanguagesModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
