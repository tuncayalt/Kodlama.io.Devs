using Application.Features.ApplicationUsers.Commands.CreateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.ApplicationUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, CreatedApplicationUserDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType));
            
            CreateMap<CreateApplicationUserCommand, ApplicationUser>();
            CreateMap<CreateApplicationUserCommand, User>();
            
            CreateMap<ApplicationUser, LoggedInApplicationUserDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType));
        }
    }
}
