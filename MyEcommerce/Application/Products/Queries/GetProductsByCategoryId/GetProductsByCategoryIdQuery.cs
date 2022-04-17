using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQuery : IRequest<List<Product>>
    {
        public Guid CategoryId { get; set; }    
    }
}
