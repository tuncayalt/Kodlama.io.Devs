using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTechnologyCommand, Technology>();
            CreateMap<Technology, CreatedTechnologyDto>();

            CreateMap<UpdateTechnologyCommand, Technology>();
            CreateMap<Technology, UpdatedTechnologyDto>();

            CreateMap<Technology, DeletedTechnologyDto>();

            CreateMap<Technology, GetByIdTechnologyDto>()
                .ForMember(dst => dst.LanguageName, opt => opt.MapFrom(src => src.Language.Name));

            CreateMap<IPaginate<Technology>, GetListTechnologyModel>();
            CreateMap<Technology, GetListTechnologyDto>()
                .ForMember(dst => dst.LanguageName, opt => opt.MapFrom(src => src.Language.Name));
        }
    }
}
