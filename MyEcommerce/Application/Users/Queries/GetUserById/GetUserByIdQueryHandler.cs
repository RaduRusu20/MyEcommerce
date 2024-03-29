﻿using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

namespace Application.Users.Queries.GetCustomerById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return _repository.FindCustomerByIdAsync(query.Id, cancellationToken);
        }
    }
}
