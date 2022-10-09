using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, GetListOperationClaimsModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListOperationClaimsModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            var getListOperationClaimsModel = _mapper.Map<GetListOperationClaimsModel>(operationClaims);
            return getListOperationClaimsModel;
        }
    }
}
