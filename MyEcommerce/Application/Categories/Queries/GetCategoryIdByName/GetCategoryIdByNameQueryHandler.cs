using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryIdByName
{
    public class GetCategoryIdByNameQueryHandler : IRequestHandler<GetCategoryIdByNameQuery, Guid>
    {
        private ICategoryRepository _repository;

        public GetCategoryIdByNameQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;   
        }

        public async Task<Guid> Handle(GetCategoryIdByNameQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindIdByNameAsync(query.Name, cancellationToken);
        }
    }
}
