using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public User User { get; set; }
    }
}
