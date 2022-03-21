using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity item);
        public List<TEntity> GetAll();
        public TEntity GetById(Guid id);
        public void Delete(Guid id);
        public void Update(TEntity item);
     }      
}
