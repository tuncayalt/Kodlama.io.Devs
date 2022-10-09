using Application.Features.Auth.Commands.RegisterCommands;
using Application.Features.Auth.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterDto, RegisterCommand>();

            CreateMap<ApplicationUser, RegisteredDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType));
            
            CreateMap<RegisterCommand, ApplicationUser>();
            CreateMap<RegisterCommand, User>();
            
            CreateMap<ApplicationUser, LoggedInDto>()
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.User.Status))
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dst => dst.AuthenticatorType, opt => opt.MapFrom(src => src.User.AuthenticatorType));
        }
    }
}
