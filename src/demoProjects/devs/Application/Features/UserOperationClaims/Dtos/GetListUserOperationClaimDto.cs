using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetListUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OperationClaim Claim { get; set; }
    }
}
