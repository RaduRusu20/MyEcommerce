using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategorByName
{
    public class GetCategoryByNameQuery : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
