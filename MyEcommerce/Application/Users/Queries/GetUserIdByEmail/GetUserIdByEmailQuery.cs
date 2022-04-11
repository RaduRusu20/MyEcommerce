using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserIdByEmail
{
    public class GetUserIdByEmailQuery : IRequest<Guid>
    {
        public string Email { get; set; }
    }
}
