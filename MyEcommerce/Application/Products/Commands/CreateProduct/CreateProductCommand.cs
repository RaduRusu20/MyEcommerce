using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int AvailableQuantity { get; set; }  

        public Guid CategoryId { get; set; }

        public string Img { get; set; }

    }
}
