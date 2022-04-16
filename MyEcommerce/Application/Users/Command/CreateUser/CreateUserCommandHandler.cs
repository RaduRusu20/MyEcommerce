using Domain;
using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

namespace Application.Users.Command.CreateCustomer
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var customer = new User(command.FirstName, command.LastName, command.Email, command.Password, command.Adress, command.Phone, command.Role);
            customer.Password = MyCryptography.EncryptPlainTextToCipherText(customer.Password);
            _repository.CreateCustomeryAsync(customer, cancellationToken);
            return Task.FromResult(customer.Id);
        }
    }
}
