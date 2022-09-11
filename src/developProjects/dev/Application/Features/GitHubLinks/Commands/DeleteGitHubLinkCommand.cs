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
    public class DeleteGitHubLinkCommand : IRequest<DeletedGitHubLinkDto>
    {
        public int Id { get; private set; }

        public class DeleteGitHubLinkCommandHandler : IRequestHandler<DeleteGitHubLinkCommand, DeletedGitHubLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubLinkRepository _gitHubLinkRepository;


            public DeleteGitHubLinkCommandHandler(IMapper mapper, IGitHubLinkRepository gitHubLinkRepository)
            {
                _mapper = mapper;
                _gitHubLinkRepository = gitHubLinkRepository;

            }

            public async Task<DeletedGitHubLinkDto> Handle(DeleteGitHubLinkCommand request, CancellationToken cancellationToken)
            {
                GitHubLink? gitHubLink = await _gitHubLinkRepository.GetAsync(g => g.Id == request.Id);

                GitHubLink deletedGitHubLink = await _gitHubLinkRepository.DeleteAsync(gitHubLink!);
                DeletedGitHubLinkDto deletedGitHubLinkDto = _mapper.Map<DeletedGitHubLinkDto>(deletedGitHubLink);

                return deletedGitHubLinkDto;
            }
        }
    }
}
