using Application.Features.Languages.Dtos;
using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.OperationClaims.Models
{
    public class GetListOperationClaimsModel : BasePageableModel
    {
        public IList<GetListOperationClaimDto> Items { get; set; }
    }
}
