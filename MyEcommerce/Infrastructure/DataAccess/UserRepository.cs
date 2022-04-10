using Domain.RepositoryPattern;
using Domain.Users;

namespace Infrastructure.DataAccess
{
    public class UserRepository : ICustomerRepository
    {

        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public async Task CreateCustomeryAsync(User customer, CancellationToken cancellationToken)
        {
            _users.Add(customer);
        }

        public async Task DeleteCustomeryAsync(User customer, CancellationToken cancellationToken)
        {
            _users.Remove(customer);
        }

        public async Task<User> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return _users.SingleOrDefault(x => x.Id == customerId);
        }

        public async Task<List<User>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return _users;
        }

        public async Task UpdateCustomerAsync(User customer, CancellationToken cancellationToken)
        {
            int i;

            for (i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == customer.Id)
                {
                    _users[i] = customer;
                }
            }
        }
    }
}
