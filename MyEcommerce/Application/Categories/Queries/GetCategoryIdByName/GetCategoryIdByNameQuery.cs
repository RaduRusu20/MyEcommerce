using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryIdByName
{
    public class GetCategoryIdByNameQuery : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
