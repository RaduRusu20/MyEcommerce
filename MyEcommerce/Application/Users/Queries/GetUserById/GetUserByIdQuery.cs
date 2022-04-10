using Domain.Users;
using MediatR;

namespace Application.Users.Queries.GetCustomerById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
