using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateLanguageCommand, Language>();
            CreateMap<Language, CreatedLanguageDto>();

            CreateMap<UpdateLanguageCommand, Language>();
            CreateMap<Language, UpdatedLanguageDto>();

            CreateMap<Language, DeletedLanguageDto>();
        }
    }
}
