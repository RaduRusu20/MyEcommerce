using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;


        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price);
            _repository.CreateProductAsync(product, cancellationToken);
            return Task.FromResult(product.Id);
        }
    }
}
