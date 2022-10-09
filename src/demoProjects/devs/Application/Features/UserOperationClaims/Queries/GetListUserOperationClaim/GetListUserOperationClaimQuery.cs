using Application.Features.UserOperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<GetListUserOperationClaimsModel>, ISecuredRequest
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { "Admin" };
    }
}
