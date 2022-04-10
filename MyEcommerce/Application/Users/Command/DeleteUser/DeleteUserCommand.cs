using Domain.Users;
using MediatR;

namespace Application.Users.Command.DeleteCustomer
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public User User { get; set; }
    }
}
