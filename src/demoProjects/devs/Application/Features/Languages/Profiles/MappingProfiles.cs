using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
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

            CreateMap<Language, GetByIdLanguageDto>();

            CreateMap<IPaginate<Language>, GetListLanguagesModel>();
            CreateMap<Language, GetListLanguageDto>();
        }
    }
}
