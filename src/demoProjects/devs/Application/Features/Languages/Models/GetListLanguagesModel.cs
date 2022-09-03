using Application.Features.Languages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Languages.Models
{
    public class GetListLanguagesModel : BasePageableModel
    {
        public IList<GetListLanguageDto> Items { get; set; }
    }
}