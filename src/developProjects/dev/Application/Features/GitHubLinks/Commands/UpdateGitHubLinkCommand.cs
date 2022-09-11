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
    public class UpdateGitHubLinkCommand : IRequest<UpdatedGitHubLinkDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateGitHubLinkCommandHandler : IRequestHandler<UpdateGitHubLinkCommand, UpdatedGitHubLinkDto>
    {
        private readonly IMapper _mapper;
        private readonly IGitHubLinkRepository _gitHubLinkRepository;

        public UpdateGitHubLinkCommandHandler(IMapper mapper, IGitHubLinkRepository gitHubLinkRepository)
        {
            _mapper = mapper;
            _gitHubLinkRepository = gitHubLinkRepository;

        }
        public async Task<UpdatedGitHubLinkDto> Handle(UpdateGitHubLinkCommand request, CancellationToken cancellationToken)
        {
            GitHubLink mappedGitHubLink = _mapper.Map<GitHubLink>(request);
            GitHubLink updatedGitHubLink = await _gitHubLinkRepository.UpdateAsync(mappedGitHubLink);
            UpdatedGitHubLinkDto updatedGitHubLinkDto = _mapper.Map<UpdatedGitHubLinkDto>(updatedGitHubLink);
            return updatedGitHubLinkDto;
        }

    }
}

