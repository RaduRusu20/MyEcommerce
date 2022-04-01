using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Guid>
    {
        private ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            _repository.DeleteCategoryAsync(command.Category, cancellationToken);
            return Task.FromResult(command.Category.Id);
        }
    }
}
