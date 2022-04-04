using Application.Categories.Queries.GetCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryReader
    {
         IEnumerable<CategoryDto> ReadAllCategories();
    }
}
