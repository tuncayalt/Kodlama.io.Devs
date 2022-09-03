using Application.Features.Languages.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<GetListLanguagesModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
