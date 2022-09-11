using Application.Features.GitHubLinks.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubLinks.Models
{
    public class GitHubLinkListModel : BasePageableModel
    {
        public IList<GitHubLinkListDto> Items { get; set; }
    }
}
