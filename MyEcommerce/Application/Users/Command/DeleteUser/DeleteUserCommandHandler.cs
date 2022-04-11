using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.DeleteCustomer
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            _repository.DeleteCustomeryAsync(command.User, cancellationToken);
            return Task.FromResult(command.User.Id);
        }
    }
}
