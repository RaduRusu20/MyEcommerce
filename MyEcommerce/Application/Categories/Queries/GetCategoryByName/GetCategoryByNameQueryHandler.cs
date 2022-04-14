using Application.Categories.Queries.GetCategorByName;
using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, Category>
    {
        private ICategoryRepository _repository;

        public GetCategoryByNameQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;   
        }

        public async Task<Category> Handle(GetCategoryByNameQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindCategoryByNameAsync(query.Name, cancellationToken);
        }

    }
}
