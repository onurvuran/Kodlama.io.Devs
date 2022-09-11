using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GitHubLink : Entity
    {
        public string? Url { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public GitHubLink()
        {
        }

        public GitHubLink(string? url, int userId, User? user)
        {
            Url = url;
            UserId = userId;
            User = user;
        }
    }
}
