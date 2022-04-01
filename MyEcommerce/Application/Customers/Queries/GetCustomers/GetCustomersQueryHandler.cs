using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private ICustomerRepository _repository;

        public GetCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCustomersAsync(cancellationToken);
        }
    }
}
