
using Application.Features.GitHubLinks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubLinks.Commands
{
    public class CreateGitHubLinkCommand : IRequest<CreatedGitHubLinkDto>
    {
        public string Url { get; set; }
        public int UserId { get; set; }

        public class CreateGitHubLinkCommandHandler : IRequestHandler<CreateGitHubLinkCommand, CreatedGitHubLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubLinkRepository _gitHubLinkRepository;


            public CreateGitHubLinkCommandHandler(IMapper mapper, IGitHubLinkRepository gitHubLinkRepository)
            {
                _mapper = mapper;
                _gitHubLinkRepository = gitHubLinkRepository;

            }

            public async Task<CreatedGitHubLinkDto> Handle(CreateGitHubLinkCommand request, CancellationToken cancellationToken)
            {
                GitHubLink mappedGitHubAddress = _mapper.Map<GitHubLink>(request);
                GitHubLink createdGitHubAddress = await _gitHubLinkRepository.AddAsync(mappedGitHubAddress);
                CreatedGitHubLinkDto createdGitHubAddressDto = _mapper.Map<CreatedGitHubLinkDto>(createdGitHubAddress);
                return createdGitHubAddressDto;
            }
        }
    }
}

