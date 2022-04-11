using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

namespace Application.Users.Queries.GetCustomers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private IUserRepository _repository;

        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCustomersAsync(cancellationToken);
        }
    }
}
