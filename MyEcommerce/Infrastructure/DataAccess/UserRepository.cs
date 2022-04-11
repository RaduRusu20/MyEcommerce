using Domain.RepositoryPattern;
using Domain.Users;
using Infrastructure.Persistence;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {

        private EcommerceContext ecommerceContext;

        public UserRepository()
        {
            ecommerceContext = new EcommerceContext();
        }

        public async Task CreateCustomeryAsync(User customer, CancellationToken cancellationToken)
        {
            ecommerceContext.Users.Add(customer);
            ecommerceContext.SaveChanges();
        }

        public async Task DeleteCustomeryAsync(User customer, CancellationToken cancellationToken)
        {
            ecommerceContext.Users.Remove(customer);
            ecommerceContext.SaveChanges();
        }

        public async Task<User> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return ecommerceContext.Users.SingleOrDefault(x => x.Id == customerId);
        }

        public async Task<List<User>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.Users.ToList();
        }

        public async Task UpdateCustomerAsync(User customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> FindCustomerIdByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return ecommerceContext.Users.FirstOrDefault(x => x.Email == email).Id;
        }
    }
}
