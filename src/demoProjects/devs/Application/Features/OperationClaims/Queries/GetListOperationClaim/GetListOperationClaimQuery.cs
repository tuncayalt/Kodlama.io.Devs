using Application.Features.OperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<GetListOperationClaimsModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { "Admin" };
    }
}
