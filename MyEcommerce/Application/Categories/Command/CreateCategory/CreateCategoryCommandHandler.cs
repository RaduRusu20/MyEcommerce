using Domain.Products;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = Category.CreateCategory(command.Name);
            _repository.CreateCategoryAsync(category, cancellationToken);
            return Task.FromResult(category.Id);
        }
    }
}
