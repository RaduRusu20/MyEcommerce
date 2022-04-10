using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface ICustomerRepository
    {
        public Task CreateCustomeryAsync(User customer, CancellationToken cancellationToken);

        public Task UpdateCustomerAsync(User customer, CancellationToken cancellationToken);

        public Task DeleteCustomeryAsync(User customer, CancellationToken cancellationToken);

        public Task<User> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken);

        public Task<List<User>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
