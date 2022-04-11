using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserIdByEmail
{
    public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmailQuery, Guid>
    {
        private IUserRepository _repository;

        public GetUserIdByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;   
        }

        public async Task<Guid> Handle(GetUserIdByEmailQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindCustomerIdByEmailAsync(query.Email, cancellationToken);
        }
    }
}
