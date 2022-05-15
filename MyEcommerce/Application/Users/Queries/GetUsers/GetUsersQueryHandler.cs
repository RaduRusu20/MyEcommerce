using Domain;
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

            var list = await _repository.GetAllCustomersAsync(cancellationToken);
            list.ForEach(x => x.Password = MyCryptography.DecryptCipherTextToPlainText(x.Password));
            return list;
        }
    }
}
