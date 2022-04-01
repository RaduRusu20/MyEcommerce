﻿using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }
}
