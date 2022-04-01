using Domain.Customers;
using Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {

        private List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public async Task CreateCustomeryAsync(Customer customer, CancellationToken cancellationToken)
        {
            _customers.Add(customer);
        }

        public async Task DeleteCustomeryAsync(Customer customer, CancellationToken cancellationToken)
        {
            _customers.Remove(customer);
        }

        public async Task<Customer> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return _customers.SingleOrDefault(x => x.Id == customerId);
        }

        public async Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return _customers;
        }

        public async Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            int i;

            for (i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Id == customer.Id)
                {
                    _customers[i] = customer;
                }
            }
        }
    }
}
