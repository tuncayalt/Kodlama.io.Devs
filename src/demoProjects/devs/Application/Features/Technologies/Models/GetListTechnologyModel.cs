using Application.Features.Technologies.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Technologies.Models
{
    public class GetListTechnologyModel : BasePageableModel
    {
        public IList<GetListTechnologyDto> Items { get; set; }
    }
}
