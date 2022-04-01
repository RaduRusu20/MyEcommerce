using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface ICustomerRepository
    {
        public Task CreateCustomeryAsync(Customer customer, CancellationToken cancellationToken);

        public Task UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken);

        public Task DeleteCustomeryAsync(Customer customer, CancellationToken cancellationToken);

        public Task<Customer> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken);

        public Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
