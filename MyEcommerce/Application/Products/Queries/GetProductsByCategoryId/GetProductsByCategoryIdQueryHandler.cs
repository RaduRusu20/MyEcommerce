using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<Product>>
    {
        private IProductRepository _repository;

        public GetProductsByCategoryIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetProductsByCategoryIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsByCategoryId(query.CategoryId, cancellationToken);
        }
    }
}
