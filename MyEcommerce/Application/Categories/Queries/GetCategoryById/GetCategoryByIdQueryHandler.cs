using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = _repository.FindCategoryByIdAsync(query.Id, cancellationToken);
            return await category;
        }
    }
}
