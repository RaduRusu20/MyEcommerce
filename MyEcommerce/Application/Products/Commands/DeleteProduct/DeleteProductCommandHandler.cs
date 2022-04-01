using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;

        }

        public Task<Guid> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            _repository.DeleteProductAsync(command.Product, cancellationToken);
            return Task.FromResult(command.Product.Id);
        }
    }
}
