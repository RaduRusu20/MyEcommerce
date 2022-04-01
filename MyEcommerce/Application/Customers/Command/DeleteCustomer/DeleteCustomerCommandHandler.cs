using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Guid>
    {
        private ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            _repository.DeleteCustomeryAsync(command.Customer, cancellationToken);
            return Task.FromResult(command.Customer.Id);
        }
    }
}
