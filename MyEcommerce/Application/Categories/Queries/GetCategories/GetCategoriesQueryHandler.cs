using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private ICategoryRepository _repository;

        public GetCategoriesQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
           return await _repository.GetAllCategoriesAsync(cancellationToken);
        }
    }
}
