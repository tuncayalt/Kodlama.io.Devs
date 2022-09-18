using Application.Features.Technologies.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<GetListTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
