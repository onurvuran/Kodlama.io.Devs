using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class LoginUserQuery : UserForLoginDto, IRequest<LoggedInUserDto>
    {
        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoggedInUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _userBusinessRules;

            public LoginUserQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<LoggedInUserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.Email);

                UserBusinessRules.UserShouldBeExistWhenLoggedIn(user);
                UserBusinessRules.UserCredentialsShouldBeMatchWhenLoggedIn(user!, request.Password);

                IList<OperationClaim> operationClaims = _userRepository.GetClaims(user!);

                AccessToken token = _tokenHelper.CreateToken(user!, operationClaims);

                LoggedInUserDto loggedInUserDto = _mapper.Map<LoggedInUserDto>(token);

                return loggedInUserDto;
            }
        }
    }
}
