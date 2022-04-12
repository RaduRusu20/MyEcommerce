using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductByName
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, Product>
    {
        private IProductRepository _repository;

        public GetProductByNameQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByNameQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindProductByNameAsync(query.Name, cancellationToken);
        }
    }
}
