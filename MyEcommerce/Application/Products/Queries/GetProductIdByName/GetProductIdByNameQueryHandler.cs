using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductIdByName
{
    public class GetProductIdByNameQueryHandler : IRequestHandler<GetProductIdByNameQuery, Guid>
    {
        private IProductRepository _repository;

        public GetProductIdByNameQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(GetProductIdByNameQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindProductIdByNameAsync(query.Name, cancellationToken);
        }
    }
}
