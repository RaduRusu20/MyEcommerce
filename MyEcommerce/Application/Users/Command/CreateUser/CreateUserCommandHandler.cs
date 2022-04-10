using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

namespace Application.Users.Command.CreateCustomer
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private ICustomerRepository _repository;

        public CreateUserCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var customer = new User(command.FirstName, command.LastName, command.Email, command.Password, command.Adress, command.Phone, command.Role);
            _repository.CreateCustomeryAsync(customer, cancellationToken);
            return Task.FromResult(customer.Id);
        }
    }
}
