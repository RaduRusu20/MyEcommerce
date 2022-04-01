using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return _repository.FindCustomerByIdAsync(query.Id, cancellationToken);
        }
    }
}
