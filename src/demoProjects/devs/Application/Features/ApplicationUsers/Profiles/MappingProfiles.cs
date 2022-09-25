using Application.Features.ApplicationUsers.Commands.UpdateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ApplicationUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdateApplicationUserCommand, ApplicationUser>();
            CreateMap<ApplicationUser, UpdatedApplicationUserDto>();

            CreateMap<ApplicationUser, DeletedApplicationUserDto>();

            CreateMap<ApplicationUser, GetByIdApplicationUserDto>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType));

            CreateMap<IPaginate<ApplicationUser>, GetListApplicationUsersModel>();
            CreateMap<ApplicationUser, GetListApplicationUserDto>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType)); ;
        }
    }
}
