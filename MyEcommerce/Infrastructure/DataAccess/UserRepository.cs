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
            await ecommerceContext.Users.AddAsync(customer, cancellationToken);
            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCustomeryAsync(User customer, CancellationToken cancellationToken)
        {
            ecommerceContext.Users.Remove(customer);
            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<User> FindCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return await ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .SingleOrDefaultAsync(x => x.Id == customerId);
        }

        public async Task<List<User>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            return await ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .ToListAsync();
        }

        public async Task UpdateCustomerAsync(User newUser, Guid id, CancellationToken cancellationToken)
        {
            var user = await ecommerceContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            newUser.Id = id;

            if (user != null)
            {
                ecommerceContext.Entry(user).CurrentValues.SetValues(newUser);
            }

            ecommerceContext.SaveChanges();
        }

        public async Task<User> FindCustomerByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await ecommerceContext.Users
                .Include(u => u.ShoppingCart)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
