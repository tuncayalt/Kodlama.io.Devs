using Application.Features.Technologies.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Technologies.Queries.GetListByDynamicTechnology
{
    public class GetListTechnologyByDynamicQuery : IRequest<GetListTechnologyModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
    }
}
