using Domain.Users;
using MediatR;

namespace Application.Users.Queries.GetCustomers
{
    public class GetUsersQuery : IRequest<List<User>>
    {
    }
}
