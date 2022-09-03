using Application.Features.Languages.Dtos;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<GetByIdLanguageDto>
    {
        public int Id { get; set; }
    }
}
