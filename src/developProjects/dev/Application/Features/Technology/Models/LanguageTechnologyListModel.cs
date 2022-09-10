using Application.Features.Technology.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Models
{
    public class LanguageTechnologyListModel : BasePageableModel
    {
        public IList<LanguageTechnologyListDto> Items { get; set; }

    }
}
