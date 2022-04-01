using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateCustomer(command.FirstName, command.LastName, command.Email, command.Password, command.Adress, command.Phone);
            _repository.CreateCustomeryAsync(customer, cancellationToken);
            return Task.FromResult(customer.Id);
        }
    }
}
