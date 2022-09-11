using Application.Features.GitHubLinks.Commands;
using Application.Features.GitHubLinks.Dtos;
using Application.Features.GitHubLinks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubLinks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubLink, GitHubLinkListDto>()
                .ForMember(c => c.UserFirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.UserLastName, opt => opt.MapFrom(c => c.User.LastName))
                .ReverseMap();
            CreateMap<IPaginate<GitHubLink>, GitHubLinkListModel>().ReverseMap();
            CreateMap<GitHubLink, CreatedGitHubLinkDto>().ReverseMap();
            CreateMap<GitHubLink, CreateGitHubLinkCommand>().ReverseMap();
            CreateMap<GitHubLink, UpdatedGitHubLinkDto>().ReverseMap();
            CreateMap<GitHubLink, UpdateGitHubLinkCommand>().ReverseMap();
            CreateMap<GitHubLink, DeletedGitHubLinkDto>().ReverseMap();
            CreateMap<GitHubLink, DeleteGitHubLinkCommand>().ReverseMap();
        }
    }
}
