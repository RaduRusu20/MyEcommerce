using Domain.RepositoryPattern;
using Domain.Users;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {

        private EcommerceContext ecommerceContext;

        public UserRepository(EcommerceContext _ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
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
            return ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .SingleOrDefault(x => x.Id == customerId);
        }

        public async Task<List<User>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .ToList();
        }

        public async Task UpdateCustomerAsync(User customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindCustomerByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .FirstOrDefault(x => x.Email == email);
        }
    }
}
