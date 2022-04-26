using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Guid>
    {
        private ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _repository.FindCategoryByIdAsync(command.Id, cancellationToken);
            category.Name = command.Name;
            
            await _repository.UpdateCategoryAsync(category, cancellationToken);
            return command.Id;
        }
    }
}
