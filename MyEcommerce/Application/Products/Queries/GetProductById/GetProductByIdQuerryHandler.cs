using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuerryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private IProductRepository _repository;

        public GetProductByIdQuerryHandler(IProductRepository repository)
        {
            _repository = repository;    
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = _repository.FindProductByIdAsync(query.Id, cancellationToken);

            return await product;
        }
    }
}
