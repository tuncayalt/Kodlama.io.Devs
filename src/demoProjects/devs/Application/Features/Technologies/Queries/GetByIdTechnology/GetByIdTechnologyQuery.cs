using Application.Features.Technologies.Dtos;
using MediatR;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
    {
        public int Id { get; set; }
    }
}
