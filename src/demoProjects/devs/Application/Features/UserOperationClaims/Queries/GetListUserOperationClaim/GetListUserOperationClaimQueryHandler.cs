using Application.Features.Languages.Models;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, GetListUserOperationClaimsModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly GetListUserOperationClaimBusinessRules _getListUserOperationClaimBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public GetListUserOperationClaimQueryHandler(
            IUserRepository userRepository, 
            IMapper mapper, 
            GetListUserOperationClaimBusinessRules getListUserOperationClaimBusinessRules,
            IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _getListUserOperationClaimBusinessRules = getListUserOperationClaimBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<GetListUserOperationClaimsModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.UserId);
            _getListUserOperationClaimBusinessRules.UserShouldExist(user);

            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                x => x.UserId == request.UserId, 
                include: x => x.Include(a => a.OperationClaim),
                index: request.PageRequest.Page, 
                size: request.PageRequest.PageSize);
            var getListUserOperationClaimsModel = _mapper.Map<GetListUserOperationClaimsModel>(userOperationClaims);
            return getListUserOperationClaimsModel;
        }
    }
}
