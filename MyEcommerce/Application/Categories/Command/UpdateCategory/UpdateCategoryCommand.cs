using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
