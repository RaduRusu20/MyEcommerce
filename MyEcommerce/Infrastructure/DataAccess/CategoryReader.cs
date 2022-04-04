using Application.Categories.Queries.GetCategories.Models;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    internal class CategoryReader : ICategoryReader
    {
        public IEnumerable<CategoryDto> ReadAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
