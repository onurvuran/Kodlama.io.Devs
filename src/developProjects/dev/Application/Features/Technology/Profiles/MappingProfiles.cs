

using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using AutoMapper;
using Domain.Entities;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technology.Commands;

namespace Application.Features.Technology.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.Language.Name))
                .ReverseMap();
            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();

            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();




        }
    }
}
