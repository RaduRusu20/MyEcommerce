using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductIdByName
{
    public class GetProductIdByNameQuery : IRequest<Guid> 
    {
        public string Name { get; set; }    
    }
}
