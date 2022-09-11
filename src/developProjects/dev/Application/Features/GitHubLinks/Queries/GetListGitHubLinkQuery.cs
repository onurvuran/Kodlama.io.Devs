using Application.Features.GitHubLinks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubLinks.Queries
{
    public class GetListGitHubLinkQuery : IRequest<GitHubLinkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGitHubLinkQueryHandler : IRequestHandler<GetListGitHubLinkQuery, GitHubLinkListModel>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubLinkRepository _gitHubLinkRepository;


            public GetListGitHubLinkQueryHandler(IMapper mapper, IGitHubLinkRepository gitHubLinkRepository)
            {
                _mapper = mapper;
                _gitHubLinkRepository = gitHubLinkRepository;

            }

            public async Task<GitHubLinkListModel> Handle(GetListGitHubLinkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubLink> gitHubAddresses = await _gitHubLinkRepository.GetListAsync(
                                                                include: l => l.Include(c => c.User),
                                                                index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize
                                                                );
                GitHubLinkListModel model = _mapper.Map<GitHubLinkListModel>(gitHubAddresses);
                return model;
            }

        }


    }
}
