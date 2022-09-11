using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<AccessToken, RegisteredUserDto>().ReverseMap();

            CreateMap<User, LoginUserQuery>().ReverseMap();
            CreateMap<AccessToken, LoggedInUserDto>().ReverseMap();
        }
    }
}
