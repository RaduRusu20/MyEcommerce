using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserIdByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private IUserRepository _repository;

        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;   
        }

        public async Task<User> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindCustomerByEmailAsync(query.Email, cancellationToken);
        }
    }
}
