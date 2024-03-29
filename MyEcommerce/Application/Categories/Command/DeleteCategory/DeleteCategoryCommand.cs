﻿using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Guid>
    {
        public Category Category { get; set; }
    }
}
