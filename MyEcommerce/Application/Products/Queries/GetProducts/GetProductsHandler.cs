using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllProductsAsync(cancellationToken);
        }
    }
}
