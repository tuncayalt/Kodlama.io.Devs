using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserOperationClaimCommand, OperationClaim>();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>();

            CreateMap<IPaginate<UserOperationClaim>, GetListUserOperationClaimsModel>();
            CreateMap<UserOperationClaim, GetListUserOperationClaimDto>()
                .ForMember(dst => dst.Claim, opt => opt.MapFrom(src => src.OperationClaim));
        }
    }
}
