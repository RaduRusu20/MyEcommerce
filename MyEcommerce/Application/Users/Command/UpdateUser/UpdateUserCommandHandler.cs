using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            await _repository.UpdateCustomerAsync(command.User, command.Id, cancellationToken);

            return command.Id;
        }
    }
}
